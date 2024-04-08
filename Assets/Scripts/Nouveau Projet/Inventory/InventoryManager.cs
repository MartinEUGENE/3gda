using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponSystem> weaponSlots = new List<WeaponSystem>(6);
    public int[] weaponLvls = new int[5];
    public List<PassiveItem> passiveSlots = new List<PassiveItem>(6);
    public int[] passiveLvls = new int[5];

    [System.Serializable]
    public class WeaponUpgrade
    {
        public GameObject initialWeapaon;
        public WeaponStats weaponStats; 
    }

    [System.Serializable]
    public class PassiveUpgrade
    {
        public GameObject initialPassive;
        public PassiveScriptable passiveStats;

    }

    [System.Serializable]
    public class UpgradeUI
    {
        public TextMeshPro upgradeName; 
        public TextMeshPro upgradeDescrption;
        public Image upgradeImg;
        public Button buttonUpgrade; 
    }

    public List<WeaponUpgrade> wpnUpgradeOptions = new List<WeaponUpgrade>();
    public List<PassiveUpgrade> passiveUpgradeOptions = new List<PassiveUpgrade>();
    public List<UpgradeUI> UpgradeOptions = new List<UpgradeUI>();

    CharacterStats chara;

    void Start()
    {
        chara = GetComponent<CharacterStats>(); 
    }

    public void AddWeapon(int slotsIndex, WeaponSystem weapon)
    {
        weaponSlots[slotsIndex] = weapon;
        weaponLvls[slotsIndex] = weapon.weaponData.Level;
        
        if(GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
        {
            GameManager.instance.DoneLevelling(); 
        }
    }

    public void AddPassive(int slotsIndex, PassiveItem item)
    {
        passiveSlots[slotsIndex] = item;
        passiveLvls[slotsIndex] = item.passiveItem.Level;

        if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
        {
            GameManager.instance.DoneLevelling();
        }
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if(weaponSlots.Count > slotIndex)
        {
            WeaponSystem weapon = weaponSlots[slotIndex];
            GameObject weaponUpgrade = Instantiate(weapon.weaponData.NextWeapon, transform.position, Quaternion.identity);
            weaponUpgrade.transform.SetParent(transform);
            //Méthode de spawn de l'arme chez le joueur. 

            AddWeapon(slotIndex, weaponUpgrade.GetComponentInChildren<WeaponSystem>());
            Destroy(weapon.gameObject);
            weaponLvls[slotIndex] = weaponUpgrade.GetComponentInChildren<WeaponSystem>().weaponData.Level;

            if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
            {
                GameManager.instance.DoneLevelling();
            }
        }
    }

    public void LevelUpPassive(int slotIndex)
    {
        if (passiveSlots.Count > slotIndex)
        {
            PassiveItem passive = passiveSlots[slotIndex];
            GameObject passiveUpgrade = Instantiate(passive.passiveItem.NextPassive, transform.position, Quaternion.identity);
            passiveUpgrade.transform.SetParent(transform);
            //Méthode de spawn de l'arme chez le joueur. 

            AddPassive(slotIndex, passiveUpgrade.GetComponent<PassiveItem>());
            Destroy(passive.gameObject);
            passiveLvls[slotIndex] = passiveUpgrade.GetComponent<PassiveItem>().passiveItem.Level;

            if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
            {
                GameManager.instance.DoneLevelling();
            }
        }
    }

    /*public*/ void ApplyUpgrade()
    {
        foreach(var upgradeOpt in UpgradeOptions)
        {
            int upgradeType = Random.Range(1, 3);
            if(upgradeType == 1)
            {
                WeaponUpgrade chosenWeapon = wpnUpgradeOptions[Random.Range(0, wpnUpgradeOptions.Count)]; 

                if(chosenWeapon != null)
                {
                    bool newWepon = false; 
                    for(int i = 0; i < weaponSlots.Count; i++)
                    {
                        if(weaponSlots[i] != null && weaponSlots[i].weaponData == chosenWeapon.weaponStats)
                        {
                            newWepon = false;
                            if(!newWepon)
                            {
                                upgradeOpt.buttonUpgrade.onClick.AddListener(() => LevelUpWeapon(i));

                                upgradeOpt.upgradeDescrption.text = chosenWeapon.weaponStats.NextWeapon.GetComponent<WeaponSystem>().weaponData.Descrip; 
                                upgradeOpt.upgradeName.text = chosenWeapon.weaponStats.NextWeapon.GetComponent<WeaponSystem>().weaponData.Named; 
                            }
                            break; 
                        }
                        else
                        {
                            newWepon = true; 
                        }
                    }
                    if(newWepon)
                    {
                        upgradeOpt.buttonUpgrade.onClick.AddListener(() => chara.SpawnedWeapon(chosenWeapon.initialWeapaon));
                        upgradeOpt.upgradeDescrption.text = chosenWeapon.weaponStats.Descrip;
                        upgradeOpt.upgradeName.text = chosenWeapon.weaponStats.Named;
                    }
                    
                }

                upgradeOpt.upgradeImg.sprite = chosenWeapon.weaponStats.Icon; 
            }

            else if(upgradeType == 2)
            {
                PassiveUpgrade chosenPassive = passiveUpgradeOptions[Random.Range(0, passiveUpgradeOptions.Count)];

                if (chosenPassive != null)
                {
                    bool newPassive = false;
                    for (int i = 0; i < passiveSlots.Count; i++)
                    {
                        if (weaponSlots[i] != null && passiveSlots[i].passiveItem == chosenPassive.passiveStats)
                        {
                            newPassive = false;
                            if (!newPassive)
                            {
                                upgradeOpt.buttonUpgrade.onClick.AddListener(() => LevelUpPassive(i));
                                upgradeOpt.upgradeDescrption.text = chosenPassive.passiveStats.NextPassive.GetComponent<PassiveItem>().passiveItem.Descrip;
                                upgradeOpt.upgradeName.text = chosenPassive.passiveStats.NextPassive.GetComponent<PassiveItem>().passiveItem.Named;
                            }
                            break;
                        }
                        else
                        {
                            newPassive = true;
                        }
                    }
                    if (newPassive)
                    {
                        upgradeOpt.buttonUpgrade.onClick.AddListener(() => chara.SpawnedPassive(chosenPassive.initialPassive));
                        upgradeOpt.upgradeDescrption.text = chosenPassive.passiveStats.Descrip;
                        upgradeOpt.upgradeName.text = chosenPassive.passiveStats.Named;
                    }

                }

                upgradeOpt.upgradeImg.sprite = chosenPassive.passiveStats.Icon;
            }

        }
    }

    void RemoveUpgradeOpt()
    {
        foreach(var upgradeOption in UpgradeOptions)
        {
            upgradeOption.buttonUpgrade.onClick.RemoveAllListeners();
        }
    }

    public void RemoveAndApplyUpgrades()
    {
        RemoveUpgradeOpt();
        ApplyUpgrade();
    }
}
