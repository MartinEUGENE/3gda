using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private Image XPBAR;
    [SerializeField] private Image HpBar;

    [SerializeField] public CharactControls chara;
    //[SerializeField] public FirstWeapon weep;
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
    public float currentRecovery;
    public float currentArmor;

    [Header("Other Stats")]
    
    public float currentpickUp;
    public float currentSpeed;

    [Header("Experience/Level")]
    public int experience = 0;
    public int experienceCap = 10;
    public int level = 1;

    public RectTransform VIDE;
    public RectTransform NoHealth;
    //public RectTransform MiniNoHealth;
    /*private float maxWidth = 0f;
    private float maxHP;
    private float maxHealth;
    private Transform miniHealth;
    private Transform miniNoHealth;*/

    [Header("Gold")]
    public int gold;

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

        experience = 0;
        gold = 0;
        level = 1;
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

        part.Pause(); 
    }

    private void Start()
    {
        experienceCap = levelRanges[0].expCapIncrease;
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
            experience -= experienceCap;
            //currentSpeed *= 1.15f;
            //currentAttack += 1;
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

        /*float newSize = experiencePercentage * maxWidth;

        newSize = Mathf.Clamp(newSize, 0f, maxWidth);

        RectTransform rectTransform = XPBAR.rectTransform;
        rectTransform.sizeDelta = new Vector2(newSize, rectTransform.sizeDelta.y);*/
    }
    public void HealthCheck()
    {
        float HPPercentage = currentNewHP / playerStats.MaxHP;
        HpBar.fillAmount = HPPercentage;


        if(currentNewHP <=0f)
        {
            Death();
        }

        /*float newHealthWidth = HPPercentage * maxHP; 
        newHealthWidth = Mathf.Clamp(newHealthWidth, 0f, maxHP);
        RectTransform healthRectTransform = HpBar.rectTransform;
        healthRectTransform.sizeDelta = new Vector2(newHealthWidth, healthRectTransform.sizeDelta.y);*/
        
        //float smallerObjectSize = newHealthWidth * (miniNoHealth / maxHP); // Adjust the size relative to the max width of the smaller object
       // miniHealth.sizeDelta = new Vector2(smallerObjectSize, miniHealth.sizeDelta.y);
    }

    public void DmgTaken(int dmg)
    {
        GameManager.GenerateFloatingText(Mathf.FloorToInt(dmg).ToString(), transform, 1f, 1f, false, false, true);
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
        HealthCheck();
        if(invincible == true)
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
