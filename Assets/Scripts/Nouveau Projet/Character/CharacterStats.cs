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
   // public float currentAttackHaste;
    public float currentCriticalRate; 
    public float currentCriticalDmg;

    [Header("Health")]
    public float currentNewHP;
    public float currentMaxHP;
   // public TextMeshProUGUI hpNumbers; 
    public float currentRecovery;
    public float currentArmor;

    public bool dmgHasBeenTaken = false;
    public float coolIt = 3f; 

    [Header("Other Stats")]
    
    public float currentpickUp;
    [Range(0f,2.9f)]public float currentSpeed;

    [Header("Experience/Level")]
    public int experience = 0;
    public int experienceCap;
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
        public int startLevel;
        public int endLevelPlus1;
        public int expCapIncrease; 
    }

    public List<LevelRange> levelRanges;

    InventoryManager inventory; 
    public PlayerCollect collect;
    ParticleSystem part; 
    public int weaponIndex;
    public int passiveIndex;

    #region Current Stats
    public float CurrentHealth
    {
        get { return currentNewHP; }
        set
        {
            if (currentNewHP != value)
            {
                currentNewHP = value;
                if(GameManager.instance != null)
                {
                    GameManager.instance.currentHealthDisp.text = "Health : " + CurrentHealth; 
                }
            }
        }
    }

    public float CurrentMaxHealth
    {
        get { return currentMaxHP; }
        set
        {
            if (currentMaxHP != value)
            {
                currentMaxHP = value;
                if (GameManager.instance != null)
                {
                    //GameManager.instance.currentHealthDisp.text = "Health : " + CurrentHealth;
                }
            }
        }
    }

    public float CurrentRecovery
    {
        get { return currentRecovery; }
        set
        {
            if (currentRecovery != value)
            {
                currentRecovery = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentRecoveryDisp.text = "Recovery : " + CurrentRecovery;
                }
            }
        }
    }
    public float CurrentArmor
    {
        get { return currentArmor; }
        set
        {
            if (currentArmor != value)
            {
                currentArmor = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentArmorDisp.text = "Armor : " + CurrentArmor;
                }
            }
        }
    }
    public float CurrentAttack
    {
        get { return currentAttack; }
        set
        {
            if (currentAttack != value)
            {
                currentAttack = Mathf.FloorToInt(value);
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentAttackDisp.text = "Attack : " + CurrentAttack;
                }
            }
        }
    }
    public float CurrentCritRate
    {
        get { return currentCriticalRate; }
        set
        {
            if (currentCriticalRate != value)
            {
                currentCriticalRate = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentCriRateDisp.text = "Crit Rate : " + CurrentCritRate;
                }
            }
        }
    }

    public float CurrentCritDmg
    {
        get { return currentCriticalDmg; }
        set
        {
            if (currentCriticalDmg != value)
            {
                currentCriticalDmg = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentCritDmgDisp.text = "Crit Damage : " + CurrentCritDmg;
                }
            }
        }
    }
    public float CurrentPickUp
    {
        get { return currentpickUp; }
        set
        {
            if (currentpickUp != value)
            {
                currentpickUp = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentPickUpDisp.text = "Magnet : " + CurrentPickUp;
                }
            }
        }
    }

    public float CurrentMovSpeed
    {
        get { return currentSpeed; }
        set
        {
            if (currentSpeed != value)
            {
                currentSpeed = value;
                if (GameManager.instance != null)
                {
                    GameManager.instance.currentMovSpeedDisp.text = "Speed : " + CurrentMovSpeed;
                }
            }
        }
    }
    #endregion 

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

        CurrentMaxHealth = playerStats.MaxHP; 
        CurrentHealth = playerStats.MaxHP; 
        CurrentAttack = playerStats.Attack;

        CurrentCritRate = playerStats.CritRate;
        CurrentCritDmg = playerStats.CritDmg;

        CurrentPickUp = playerStats.PickUp; 
        CurrentMovSpeed = playerStats.MovSpeed;
        CurrentArmor = playerStats.Armor;
        CurrentRecovery = playerStats.recovery;
        collect.SetDetection(CurrentPickUp); 

        //Weapon Spawning
        SpawnedWeapon(playerStats.StartingWeapon);

        part.Pause();
    }

    private void Start()
    {
        experienceCap = levelRanges[0].expCapIncrease;
        HealthCheck();
        StatsCheck(); 
    }

    public void SpawnedWeapon(GameObject weapon)
    {
        if(weaponIndex >= inventory.weaponSlots.Count -1)
        {
            Debug.LogError("No more Weapons to be added"); 
            return; 
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponentInChildren<WeaponSystem>());

        weaponIndex++;
    }

     public void SpawnedPassive(GameObject passive)
     {
        if (passiveIndex >= inventory.passiveSlots.Count - 1)
        {
            Debug.LogError("No more Passive Items to be added");
            return;
        }

         GameObject spawnedPassive = Instantiate(passive, transform.position, Quaternion.identity);
         spawnedPassive.transform.SetParent(transform);
         inventory.AddPassive(passiveIndex, spawnedPassive.GetComponent<PassiveItem>());

         passiveIndex++;
     }
    public void IncreaseGold(int amount)
    {
        gold += amount;
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        XPbar();
        LevelUpCheck();
    }

    public void LevelUpCheck()
    {
        if(experience >= experienceCap)  
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Collectibles/Exp/LevelUP");
            level++;
            levelTxt.text = "Lv " + level; 

            experience -= experienceCap;

            invincible = true; 

            int experienceCapIncrease = 0;
            foreach(LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevelPlus1)
                {
                    experienceCapIncrease = range.expCapIncrease;
                    break;
                }
            }

            XPbar();
            experienceCap = experienceCapIncrease;            
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
        float HPPercentage = CurrentHealth / CurrentMaxHealth;
        trueHealthBar.fillAmount = HPPercentage;

        if (CurrentHealth <= 0f)
        {
            Death();
        }

    }

    public void DmgTaken(int dmg)
    {
        //GameManager.GenerateFloatingText(Mathf.FloorToInt(dmg).ToString(), transform, 1f, 1f, false, false, true)
        healthContainer.SetActive(true);
        dmgHasBeenTaken = true;
        part.Play();
    }
    public void Death()
    {
        if (!GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();
        }
    }

    public void Healing(float amount)
    {
        if (CurrentHealth < CurrentMaxHealth)
        {
            CurrentHealth += amount;
            GameManager.GenerateFloatingText(Mathf.FloorToInt(amount).ToString(), transform, 1f, 1f, false, true, false);

            if (CurrentHealth > CurrentMaxHealth)
            {
                CurrentHealth = CurrentMaxHealth;
            }
        }
    }

    void StatsCheck()
    {
        GameManager.instance.currentHealthDisp.text = "Health : " + CurrentHealth + "/"+ CurrentMaxHealth;
        GameManager.instance.currentRecoveryDisp.text = "Recovery : " + CurrentRecovery;
        GameManager.instance.currentArmorDisp.text = "Armor : " + CurrentArmor;
        GameManager.instance.currentAttackDisp.text = "Attack : " + CurrentAttack;
        GameManager.instance.currentCriRateDisp.text = "Crit Rate : " + CurrentCritRate;
        GameManager.instance.currentCritDmgDisp.text = "Crit Damage : " + CurrentCritDmg;
        GameManager.instance.currentPickUpDisp.text = "Magnet : " + CurrentPickUp;
        GameManager.instance.currentMovSpeedDisp.text = "Speed : " + CurrentMovSpeed;
    }

    void Recover()
    {
        if (CurrentHealth < CurrentMaxHealth)
        {
            CurrentHealth += CurrentRecovery * Time.deltaTime;
        }

        if (CurrentHealth > CurrentMaxHealth)
        {
            CurrentHealth = CurrentMaxHealth;
        }
    }

    public void Update()
    {
        StatsCheck();
        HealthCheck();

        coolIt -= Time.deltaTime;
        if (coolIt <= 0f && CurrentHealth == CurrentMaxHealth)
        {
            healthContainer.SetActive(false);
        }

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

