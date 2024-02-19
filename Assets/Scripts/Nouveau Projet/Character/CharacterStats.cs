using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private Image XPBAR;

    [SerializeField] public CharactControls chara;
    //[SerializeField] public FirstWeapon weep;
    [SerializeField] public GameObject player; 
    [SerializeField] public CharacterScriptable playerStats; 
    [Header("Attack Stats")]

    public int currentAttack;
    public float currentAttackHaste;
    public float currentCriticalRate; 
    public int currentCriticalDmg;


    [Header("Health")]
    public int currentNewHP;

    [Header("Other Stats")]
    
    public int currentpickUp;
    public float currentSpeed;

    [Header("Experience/Level")]
    public int experience = 0;
    public int experienceCap = 10;
    public int level = 1;
    public RectTransform VIDE;
    private float maxWidth = 0f;

    [Header("Gold")]
    public int gold; 


    [System.Serializable]
    public class LevelRange
    {
        public int startingLevel;
        public int endLevel;
        public int expCapIncrease; 
    }

    public List<LevelRange> levelRanges;

    private void Start()
    {
        maxWidth = VIDE.rect.width;

        experienceCap = levelRanges[0].expCapIncrease;

       
        XPBAR.rectTransform.pivot = new Vector2(0, 0.5f);
    }


    void Awake()
    {
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
        if(experience >= experienceCap)  // ici pour martin: provoqué le choix d'upgrade et la monté des autres state et reset bar XP
        {
            level++;
            experience -= experienceCap;
            currentSpeed *= 1.15f;

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
        float newWidth = experiencePercentage * maxWidth;

        
        RectTransform rectTransform = XPBAR.rectTransform;
        rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y);
    }
}
