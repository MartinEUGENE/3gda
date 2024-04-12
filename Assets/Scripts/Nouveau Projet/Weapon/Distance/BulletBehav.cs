using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehav : BulletSystem
{
    List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
        //moveDir = mainCam.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 dir = moveDir; 
        rb.velocity = new Vector2(dir.x, dir.y) * weapon.speedrange; 
    }

    protected override void Update() // il tire dans la bonne direction mais une force supl�mentaire le pousse dans la direction o� se d�place le joueur, d�montr� par le fait que la balle est plus lente quand tir� loing du joueur
    {
        base.Update();
        //transform.position += moveDir * weapon.speedrange * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
                EnemiesSystem en = other.GetComponent<EnemiesSystem>();
                en.TakeDmg(GetCurrentDamage(), hasCrit);         
        }
    }
}
