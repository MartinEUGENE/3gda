using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Weapon Stats")]

public class WeaponStats : ScriptableObject
{
    public int damage;     //Dégats
    public float speedrange;  //Vitesse de déplacement d'une balle
    public int quantity;    //Quantité


    public float cooldown; 
    public float weaponReload;  //Passe le cooldown à cette valeur pour commencer le timer

    public bool pierceEffect;  // Si oui ou non on va avoir notre arme qui perce un ennemi en plus

    public GameObject prefabObj; //Oui il faut le gameObject qqpart


    //zone d'effet, je sais pas encore quoi mettre ici
}
