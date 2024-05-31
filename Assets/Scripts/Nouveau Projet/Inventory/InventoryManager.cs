using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponSystem> weaponSlots = new List<WeaponSystem>(4);
    public int[] weaponLvls = new int[4];
    public List<Image> weaponUiSlots = new List<Image>(3); 

    public List<PassiveItem> passiveSlots = new List<PassiveItem>(7);
    public int[] passiveLvls = new int[7];
    public List<Image> passiveUiSlots = new List<Image>(6);
        
    [System.Serializable]
    public class UpgradeUI
    {
        public TextMeshProUGUI upgradeName;
        public TextMeshProUGUI upgradeDescrption;
        public Image upgradeImg;
        public Button buttonUpgrade;

        private WeaponStats weaponImg;
        private PassiveScriptable passiveImg;
    }

    [System.Serializable]
    public class PassiveUpgrade
    {
        public int passiveUpIndex;
        public GameObject initialPassive;
        public PassiveScriptable passiveStats;
    }
    [System.Serializable]
    public class WeaponUpgrade
    {
        public int weaponUpIndex;
        public GameObject initialWeapaon;
        public WeaponStats weaponStats;
    }

    public List<WeaponUpgrade> wpnUp = new List<WeaponUpgrade>();
    public List<PassiveUpgrade> passiveUp = new List<PassiveUpgrade>();
    public List<UpgradeUI> psyOps = new List<UpgradeUI>();

    CharacterStats chara;
    public Sprite healingSprite;

    void Start()
    {
        chara = GetComponent<CharacterStats>();
    }

    public void AddWeapon(int slotsIndex, WeaponSystem weapon)
    {
        weaponSlots[slotsIndex] = weapon;
        weaponLvls[slotsIndex] = weapon.weaponData.Level;
        weaponUiSlots[slotsIndex].enabled = true;
        weaponUiSlots[slotsIndex].sprite = weapon.weaponData.Icon; 

        if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
        {
            GameManager.instance.LevelUpDone();
        }
    }

    public void AddPassive(int slotsIndex, PassiveItem item)
    {
        passiveSlots[slotsIndex] = item;
        passiveLvls[slotsIndex] = item.passiveItem.Level;
        passiveUiSlots[slotsIndex].enabled = true;
        passiveUiSlots[slotsIndex].sprite = item.passiveItem.Icon;


        if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
        {
            GameManager.instance.LevelUpDone();
        }
    }

    public void LevelUpWeapon(int slotIndex, int upgradeIndex)
    {
        if (weaponSlots.Count > slotIndex)
        {
            WeaponSystem weapon = weaponSlots[slotIndex];
            GameObject weaponUpgrade = Instantiate(weapon.weaponData.NextWeapon, transform.position, Quaternion.identity);
            weaponUpgrade.transform.SetParent(transform);
            //Méthode de spawn de l'arme chez le joueur. *//*

            AddWeapon(slotIndex, weaponUpgrade.GetComponentInChildren<WeaponSystem>());
            Destroy(weapon.gameObject);
            weaponLvls[slotIndex] = weaponUpgrade.GetComponentInChildren<WeaponSystem>().weaponData.Level;
            wpnUp[upgradeIndex].weaponStats = weaponUpgrade.GetComponentInChildren<WeaponSystem>().weaponData;


            if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
            {
                GameManager.instance.LevelUpDone();
            }
        }
    }

    public void RecoverHealth()
    {
        chara.Healing(chara.CurrentMaxHealth/2);         

        if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
        {
            GameManager.instance.LevelUpDone();
        }
    }

    public void LevelUpPassive(int slotIndex, int upgradeIndex)
    {
        if (passiveSlots.Count > slotIndex)
        {
            PassiveItem passive = passiveSlots[slotIndex];
            GameObject passiveUpgrade = Instantiate(passive.passiveItem.NextPassive, transform.position, Quaternion.identity);
            passiveUpgrade.transform.SetParent(transform);
            //Méthode de spawn du passif chez le joueur. 

            AddPassive(slotIndex, passiveUpgrade.GetComponent<PassiveItem>());
            Destroy(passive.gameObject);
            passiveLvls[slotIndex] = passiveUpgrade.GetComponent<PassiveItem>().passiveItem.Level;

            passiveUp[upgradeIndex].passiveStats = passiveUpgrade.GetComponent<PassiveItem>().passiveItem;


            if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
            {
                GameManager.instance.LevelUpDone();
            }
        }
    }

    void ApplyUpgrade()
    {
        List<WeaponUpgrade> avalivableWeaponUpgrades = new List<WeaponUpgrade>(wpnUp);
        List<PassiveUpgrade> avalivablePassiveUpgrades = new List<PassiveUpgrade>(passiveUp);

        foreach(var up in psyOps)
        {
            if(avalivablePassiveUpgrades.Count == 0 && avalivableWeaponUpgrades.Count == 0)
            {
                return; 
            }

            int upgradeType; 

            if(avalivableWeaponUpgrades.Count == 0)
            {
                upgradeType = 2; 
            }

            else if(avalivablePassiveUpgrades.Count == 0)
            {
                upgradeType = 1;
            }

            else
            {
                upgradeType = Random.Range(1, 3);
            }


            if (upgradeType ==1)
            {
                WeaponUpgrade chosenWeapon = avalivableWeaponUpgrades[Random.Range(0, avalivableWeaponUpgrades.Count)];
                avalivableWeaponUpgrades.Remove(chosenWeapon); 

                if (chosenWeapon != null)
                {
                    //EnableUI(up);

                    bool newWeapon = false;
                    for (int i = 0; i < weaponSlots.Count; i++)
                    {
                        if (weaponSlots[i] != null && weaponSlots[i].weaponData == chosenWeapon.weaponStats)
                        {
                            newWeapon = false;
                            if (!newWeapon)
                            {
                                if (!chosenWeapon.weaponStats.NextWeapon)
                                {
                                    up.buttonUpgrade.onClick.AddListener(() => RecoverHealth());

                                    up.upgradeImg.sprite = healingSprite;
                                    up.upgradeDescrption.text = "You will recover 50% of your Health.";
                                    up.upgradeName.text = "A small treat";

                                    break;
                                }

                                up.buttonUpgrade.onClick.AddListener(() => LevelUpWeapon(i, chosenWeapon.weaponUpIndex));

                                up.upgradeDescrption.text = chosenWeapon.weaponStats.NextWeapon.GetComponentInChildren<WeaponSystem>().weaponData.Descrip;
                                up.upgradeName.text = chosenWeapon.weaponStats.NextWeapon.GetComponentInChildren<WeaponSystem>().weaponData.Named; 
                            }
                            
                            break;
                        }

                        else
                        {
                           newWeapon = true;
                        }
                    }

                    if (newWeapon)
                    {
                        up.buttonUpgrade.onClick.AddListener(() => chara.SpawnedWeapon(chosenWeapon.initialWeapaon));
                        up.upgradeDescrption.text = chosenWeapon.weaponStats.Descrip;
                        up.upgradeName.text = chosenWeapon.weaponStats.Named;
                    }

                    up.upgradeImg.sprite = chosenWeapon.weaponStats.Icon;

                }
            }

            else if (upgradeType == 2)
            {
                PassiveUpgrade chosenPassive = avalivablePassiveUpgrades[Random.Range(0, avalivablePassiveUpgrades.Count)];
                avalivablePassiveUpgrades.Remove(chosenPassive);

                if (chosenPassive != null)
                {
                    //EnableUI(up); 

                    bool newPass = false;
                    for (int i = 0; i < passiveSlots.Count; i++)
                    {
                        if (passiveSlots[i] != null && passiveSlots[i].passiveItem == chosenPassive.passiveStats)
                        {
                            newPass = false;
                            if (!newPass)
                            {
                                if(!chosenPassive.passiveStats.NextPassive)
                                {
                                    //DisableUI(up);
                                    up.buttonUpgrade.onClick.AddListener(() => RecoverHealth());

                                    up.upgradeImg.sprite = healingSprite;
                                    up.upgradeDescrption.text = "You will recover 50% of your Health.";
                                    up.upgradeName.text = "A small treat";
                                    

                                    break;
                                }

                                //ButtonActivation(); 
                                up.buttonUpgrade.onClick.AddListener(() => LevelUpPassive(i, chosenPassive.passiveUpIndex));
                                up.upgradeDescrption.text = chosenPassive.passiveStats.NextPassive.GetComponent<PassiveItem>().passiveItem.Descrip;
                                up.upgradeName.text = chosenPassive.passiveStats.NextPassive.GetComponent<PassiveItem>().passiveItem.Named;

                            }

                            break;
                        }

                        else
                        {
                            newPass = true;
                        }
                    }
                    if (newPass)
                    {
                        up.buttonUpgrade.onClick.AddListener(() => chara.SpawnedPassive(chosenPassive.initialPassive)); 
                        up.upgradeDescrption.text = chosenPassive.passiveStats.Descrip;
                        up.upgradeName.text = chosenPassive.passiveStats.Named;
                    }

                    up.upgradeImg.sprite = chosenPassive.passiveStats.Icon;

                }
            }
        }
    }

    void RemoveUpgradeOpt()
    {
        foreach (var upgradeOption in psyOps)
        {
            upgradeOption.buttonUpgrade.onClick.RemoveAllListeners(); 
        }
    }
    
    public void RemoveUpApplyUp()
    {
        RemoveUpgradeOpt();
        ApplyUpgrade();
    }
    void DisableUI(UpgradeUI ui)
    {
        ui.upgradeName.transform.parent.gameObject.SetActive(false);
    }

    void EnableUI(UpgradeUI ui)
    {
        ui.upgradeName.transform.parent.gameObject.SetActive(true);
    }
}


/*   public void Upgrading(int[] randomIntArray)
    {
        for (int i = 0; i < psyOps.Count; i++)
        {
            if (upgradeOption[randomIntArray[i]].weaponStats != null)
            {
                psyOps[i].upgradeImg.sprite = upgradeOption[randomIntArray[i]].weaponStats.Icon;
                psyOps[i].upgradeName.text = upgradeOption[randomIntArray[i]].weaponStats.Named;
                psyOps[i].upgradeDescrption.text = upgradeOption[randomIntArray[i]].weaponStats.Descrip;

                if(upgradeOption[randomIntArray[i]].weaponStats == weaponSlots[randomIntArray[i]])
                {

                }

            }

            else if (upgradeOption[randomIntArray[i]].passiveStats != null)
            {
                psyOps[i].upgradeImg.sprite = upgradeOption[randomIntArray[i]].passiveStats.Icon;
                psyOps[i].upgradeName.text = upgradeOption[randomIntArray[i]].passiveStats.Named;
                psyOps[i].upgradeDescrption.text = upgradeOption[randomIntArray[i]].passiveStats.Descrip;



            }
        }
    }*/