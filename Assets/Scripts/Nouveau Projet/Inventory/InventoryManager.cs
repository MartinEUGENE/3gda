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
    }

    public void AddPassive(int slotsIndex, PassiveItem item)
    {
        passiveSlots[slotsIndex] = item; 
    }

    public void LevelUpWeapon(int slotIndex)
    {

    }

    public void LevelUpPassive(int slotIndex)
    {

    }

}
