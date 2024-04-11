using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponSystem> weaponSlots = new List<WeaponSystem>(6);
    public int[] weaponLvls = new int[5];
    public List<PassiveItem> passiveSlots = new List<PassiveItem>(6);
    public int[] passiveLvls = new int[5];


    [System.Serializable]
    public class Upgrade
    {
        public int weaponUpIndex;
        public GameObject initialWeapaon;
        public WeaponStats weaponStats;
        public WeaponSystem WeaponSystem;

        [Header("")]
        //====================================================//
        public int passiveUpIndex;
        public GameObject initialPassive;
        public PassiveScriptable passiveStats;
        public PassiveItem passiveItem; 
    }

    [System.Serializable]
    public class UpgradeUI
    {
        public TextMeshProUGUI upgradeName;
        public TextMeshProUGUI upgradeDescrption;
        public Image upgradeImg;
        public Button buttonUpgrade;
    }

    public List<Upgrade> upgradeOption = new List<Upgrade>();
    public List<UpgradeUI> psyOps = new List<UpgradeUI>();

    CharacterStats chara;

    void Start()
    {
        chara = GetComponent<CharacterStats>();
    }

    public void AddWeapon(int slotsIndex, WeaponSystem weapon)
    {
        weaponSlots[slotsIndex] = weapon;
        weaponLvls[slotsIndex] = weapon.weaponData.Level;

        if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
        {
            GameManager.instance.LevelUpDone();
        }
    }

    public void AddPassive(int slotsIndex, PassiveItem item)
    {
        passiveSlots[slotsIndex] = item;
        passiveLvls[slotsIndex] = item.passiveItem.Level;

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
            //Méthode de spawn de l'arme chez le joueur. 

            AddWeapon(slotIndex, weaponUpgrade.GetComponentInChildren<WeaponSystem>());
            Destroy(weapon.gameObject);
            weaponLvls[slotIndex] = weaponUpgrade.GetComponentInChildren<WeaponSystem>().weaponData.Level;

            upgradeOption[upgradeIndex].weaponStats = weaponUpgrade.GetComponentInChildren<WeaponSystem>().weaponData;

            if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
            {
                GameManager.instance.LevelUpDone();
            }
        }
    }
    public void LevelUpPassive(int slotIndex, int upgradeIndex)
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

            upgradeOption[upgradeIndex].passiveStats = passiveUpgrade.GetComponentInChildren<PassiveItem>().passiveItem;

            if (GameManager.instance != null && GameManager.instance.isChoosingUpgrade)
            {
                GameManager.instance.LevelUpDone();
            }
        }
    }

    public void Upgrading(int[] randomIntArray)
    {
        for (int i = 0; i < psyOps.Count; i++)
        {
            if (upgradeOption[randomIntArray[i]].weaponStats != null)
            {
                psyOps[i].upgradeImg.sprite = upgradeOption[randomIntArray[i]].weaponStats.Icon;
                psyOps[i].upgradeName.text = upgradeOption[randomIntArray[i]].weaponStats.Named;
                psyOps[i].upgradeDescrption.text = upgradeOption[randomIntArray[i]].weaponStats.Descrip;

                if(upgradeOption.Contains(weaponSlots)

            }

            else if (upgradeOption[randomIntArray[i]].passiveStats != null)
            {
                psyOps[i].upgradeImg.sprite = upgradeOption[randomIntArray[i]].passiveStats.Icon;
                psyOps[i].upgradeName.text = upgradeOption[randomIntArray[i]].passiveStats.Named;
                psyOps[i].upgradeDescrption.text = upgradeOption[randomIntArray[i]].passiveStats.Descrip;



            }
        }
    }


    void RemoveUpgradeOpt()
    {
        foreach (var upgradeOption in psyOps)
        {

        }
    }
    public void ButtonActivation(int buttonIndex)
    {

    }


}




/*void ApplyUpgrade()
{
    foreach (var upgradeOpt in UpgradeOptions)
    {
        int upgradeType = Random.Range(1, 3);
        if (upgradeType == 1)
        {
            WeaponUpgrade chosenWeapon = wpnUpgradeOptions[Random.Range(0, wpnUpgradeOptions.Count)];

            if (chosenWeapon != null)
            {
                bool newWeapon = false;
                for (int i = 0; i < weaponSlots.Count; i++)
                {
                    if (weaponSlots[i] != null && weaponSlots[i].weaponData == chosenWeapon.weaponStats)
                    {
                        newWeapon = false;

                        if (!newWeapon)
                        {
                            upgradeOpt.buttonUpgrade.onClick.AddListener(() => LevelUpWeapon(i, chosenWeapon.weaponUpIndex));

                            upgradeOpt.upgradeDescrption.text = chosenWeapon.weaponStats.NextWeapon.GetComponent<WeaponSystem>().weaponData.Descrip;
                            upgradeOpt.upgradeName.text = chosenWeapon.weaponStats.NextWeapon.GetComponent<WeaponSystem>().weaponData.Named;
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
                    upgradeOpt.buttonUpgrade.onClick.AddListener(() => chara.SpawnedWeapon(chosenWeapon.initialWeapaon));

                    upgradeOpt.upgradeDescrption.text = chosenWeapon.weaponStats.Descrip;
                    upgradeOpt.upgradeName.text = chosenWeapon.weaponStats.Named;
                }

            }

            upgradeOpt.upgradeImg.sprite = chosenWeapon.weaponStats.Icon;
        }

        else if (upgradeType == 2)
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
                            upgradeOpt.buttonUpgrade.onClick.AddListener(() => LevelUpPassive(i, chosenPassive.passiveUpIndex));
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
}*/
