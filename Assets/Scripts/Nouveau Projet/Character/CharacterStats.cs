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
    public int currentCriticalDmg;


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
    private float maxWidth = 0f;
    private float maxHP;
    private float maxHealth;

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

    
    void Awake()
    {
        playerStats = CharacterSelector.GetData();

        experience = 0;
        gold = 0;
        level = 1;

        currentNewHP = playerStats.MaxHP;
        player = GetComponent<GameObject>();

        
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

    }
    private void Start()
    {
        maxWidth = VIDE.rect.width;
        maxHP = NoHealth.rect.width;
        maxHealth = currentNewHP;

        experienceCap = levelRanges[0].expCapIncrease;


        XPBAR.rectTransform.pivot = new Vector2(0, 0.5f);
        HpBar.rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }
    
    public void SpawnedWeapon(GameObject weapon)
    {
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        spawnedWeapons.Add(spawnedWeapon);
    }

    public void Death()
    {
        if (currentNewHP <= 0)
        {
            chara.enabled = false;
            Destroy(gameObject);
        }
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
            level++;
            experience -= experienceCap;
            currentSpeed *= 1.15f;
            currentAttack += 1;
            invincible = true; 

            int experienceCapIncrease = 0;
            foreach(LevelRange range in levelRanges)
            {
                experienceCapIncrease = range.expCapIncrease;
                break; 
            }
            XPbar();
            experienceCap += experienceCapIncrease;
        }
    }
    void XPbar()
    {
        float experiencePercentage = (float)experience / experienceCap;
        float newSize = experiencePercentage * maxWidth;

        
        RectTransform rectTransform = XPBAR.rectTransform;
        rectTransform.sizeDelta = new Vector2(newSize, rectTransform.sizeDelta.y);
    }
    public void HealthCheck() // appeler dans l'attack de EnemiesSystem
    {// add mini health bar on the player
        
        float HPPercentage = (float)currentNewHP / maxHealth;
        float newhealth = HPPercentage * maxHP;
        //Debug.Log("ouch");
        RectTransform rectTransform = HpBar.rectTransform;
        rectTransform.sizeDelta = new Vector2(newhealth, rectTransform.sizeDelta.y);
    }

    public void Healing(float amount)
    {
        if (currentNewHP < playerStats.MaxHP)
        {
            currentNewHP += amount; 
            Debug.Log("HEAL MY GUY");
            if(currentNewHP > playerStats.MaxHP)
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
