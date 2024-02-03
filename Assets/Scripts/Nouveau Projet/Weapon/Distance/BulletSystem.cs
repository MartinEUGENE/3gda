using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    protected Vector3 dir;
    public float destroyObj = 5f;

    public int dmgQuick = 5; 
    
    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
    }

    public void DirChecker(Vector3 direction)
    {
        dir = direction;
        float dirX = dir.x;
        float dirY = dir.y;

       /* Vector3 scaling = transform.localScale;
        Vector3 rotate = transform.rotation.eulerAngles;**/
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            en.TakeDmg(dmgQuick);
        }
    }

}
