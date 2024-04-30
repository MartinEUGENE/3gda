using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private Image XPBAR;
    [SerializeField] private Image HpBar;
    [SerializeField] public Image trueHealthBar;
    [SerializeField] public GameObject healthContainer;

    [SerializeField] public CharactControls chara;
    [SerializeField] public GameObject player; 
    [SerializeField] public CharacterScriptable playerStats;

    //L'arme spawnée avec le joueur
    public List<GameObject> spawnedWeapons; 

    [Header("Attack Stats")]

    public int currentAttack;
    public float currentAttackHaste;
    public float currentCriticalRate; 
    public float currentCriticalDmg;


    [Header("Health")]
    public float currentNewHP;
   // public TextMeshProUGUI hpNumbers; 
    public float currentRecovery;
    public float currentArmor;

    public bool dmgHasBeenTaken = false;
    public float coolIt = 3f; 

    [Header("Other Stats")]
    
    public float currentpickUp;
    public float currentSpeed;

    [Header("Experience/Level")]
    public int experience = 0;
    public int experienceCap = 10;
    public int level = 1;
    public TextMeshProUGUI levelTxt; 


    [Header("Gold")]
    public int gold;
    public TextMeshProUGUI goldTxt;

    public bool invincible = false;
    public float invincibleTimer; 
    public float invincibleCooldown; 

    [System.Serializable]

    public class LevelRange
    {
        public int startingLevel;
        public int endLevel;
        public int expCapIncrease; 
    }

    public List<LevelRange> levelRanges;

    InventoryManager inventory; 
    PlayerCollect collect;
    ParticleSystem part; 
    public int weaponIndex;
    public int passiveIndex;
    
    void Awake()
    {
        //playerStats = GetComponent<CharacterScriptable>();
        playerStats = CharacterSelector.GetData();
        inventory = GetComponent<InventoryManager>();
        collect = GetComponentInChildren<PlayerCollect>();
        player = GetComponent<GameObject>();
        part = GetComponentInChildren<ParticleSystem>();

        level = 1;
        experience = 0;
        gold = 0;
        XPBAR.fillAmount = 0;

        currentNewHP = playerStats.MaxHP;        
        currentAttack = playerStats.Attack;
        //currentAttackHaste = playerStats.;
        currentCriticalRate = playerStats.CritRate;
        currentCriticalDmg = playerStats.CritDmg;

        currentpickUp = playerStats.PickUp; 
        currentSpeed = playerStats.MovSpeed;
        currentArmor = playerStats.Armor;
        currentRecovery = playerStats.recovery;
        //Weapon Spawning
        SpawnedWeapon(playerStats.StartingWeapon);

        //hpNumbers.text = string.Format("{00}/{00}", currentNewHP, playerStats.maxHP);
        part.Pause();
    }

    private void Start()
    {
        experienceCap = levelRanges[0].expCapIncrease;
        HealthCheck();
    }

    public void SpawnedWeapon(GameObject weapon)
    {
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponentInChildren<WeaponSystem>());

        weaponIndex++;
    }

     public void SpawnedPassive(GameObject passive)
     {
         GameObject spawnedPassive = Instantiate(passive, transform.position, Quaternion.identity);
         spawnedPassive.transform.SetParent(transform);
         inventory.AddPassive(passiveIndex, spawnedPassive.GetComponent<PassiveItem>());

         passiveIndex++;
     }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        XPbar();
        LevelUpCheck();
    }
    public void IncreaseGold(int amount)
    {
        gold += amount;
    }
    public void LevelUpCheck()
    {
        if(experience >= experienceCap)  // ici pour martin: provoque le choix d'upgrade et la montée des autres state et reset bar XP
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Collectibles/Exp/LevelUP");
            level++;
            levelTxt.text = "Lv " + level; 

            experience -= experienceCap;

            invincible = true; 

            int experienceCapIncrease = 0;
            foreach(LevelRange range in levelRanges)
            {
                experienceCapIncrease = range.expCapIncrease;
                break; 
            }

            XPbar();
            experienceCap += experienceCapIncrease;

            GameManager.instance.LevelUp();

        }
    }
    void XPbar()
    {
        float experiencePercentage = (float)experience / experienceCap;
        XPBAR.fillAmount = experiencePercentage;
    }

    public void HealthCheck()
    {       
        float HPPercentage = currentNewHP / playerStats.MaxHP;
       // HpBar.fillAmount = HPPercentage;
        trueHealthBar.fillAmount = HPPercentage; 
        
        if (currentNewHP <=0f)
        {
            Death();
        }

    }

    public void DmgTaken(int dmg)
    {
        //GameManager.GenerateFloatingText(Mathf.FloorToInt(dmg).ToString(), transform, 1f, 1f, false, false, true)
        dmgHasBeenTaken = true; 
        part.Play(); 
    }
    public void Death()
    {       
            if(!GameManager.instance.isGameOver)
            {
                GameManager.instance.GameOver();
            }
    }

    public void Healing(float amount)
    {
        if (currentNewHP < playerStats.MaxHP)
        {
            currentNewHP += amount;
            GameManager.GenerateFloatingText(Mathf.FloorToInt(amount).ToString(), transform, 1f, 1f, false, true, false);

            if (currentNewHP > playerStats.MaxHP)
            {
                currentNewHP = playerStats.MaxHP;
            }
        }
    }

    void StatsCheck()
    {

    }

    void Recover()
    {
        if(currentNewHP < playerStats.MaxHP)
        {
            currentNewHP += currentRecovery * Time.deltaTime;
        }

        if (currentNewHP > playerStats.MaxHP)
        {
            currentNewHP = playerStats.MaxHP;
        }
    }

    public void Update()
    {
        StatsCheck();
        HealthCheck();

        if (invincible == true)
        {
            invincibleTimer -= Time.deltaTime;
            
            if (invincibleTimer <= 0f)
            {
                invincible = false;
                invincibleTimer = invincibleCooldown;
            }
        }

        Recover();
    }

}
