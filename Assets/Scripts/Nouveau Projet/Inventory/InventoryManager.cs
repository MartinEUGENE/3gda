using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponSystem> weaponSlots = new List<WeaponSystem>(6);
    public int[] weaponLvls = new int[5];
    public List<PassiveItem> passiveSlots = new List<PassiveItem>(6);
    public int[] passiveLvls = new int[5];
    public void AddWeapon(int slotsIndex, WeaponSystem weapon)
    {
        weaponSlots[slotsIndex] = weapon;
        weaponLvls[slotsIndex] = weapon.weaponData.Level ; 
    }

    public void AddPassive(int slotsIndex, PassiveItem item)
    {
        passiveSlots[slotsIndex] = item;
        passiveLvls[slotsIndex] = item.passiveItem.Level;
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
        }
    }

}
