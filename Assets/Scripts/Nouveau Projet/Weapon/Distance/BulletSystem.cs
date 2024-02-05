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

        Vector3 scaling = transform.localScale;
        Vector3 rotate = transform.rotation.eulerAngles;

        if (dirX < 0 && dirY == 0) //left
        {
            scaling.x = scaling.x - 1;
            scaling.y = scaling.y - 1;
        }

        else if (dirX == 0 && dirY < 0) //down 
        {
            scaling.y = scaling.y - 1;
        }

        else if (dirX == 0 && dirY > 0) //up
        {
            scaling.x = scaling.x - 1;
        }

        else if (dirX > 0 && dirY > 0) //right up
        {
            rotate.z = 0f; 
        }

        else if (dirX > 0 && dirY > 0) //right down
        {
            rotate.z = -90f;
        }

        else if (dirX < 0 && dirY > 0) //left up
        {
            scaling.x = scaling.x - 1;
            scaling.y = scaling.y - 1;
            rotate.z = -90f;
        }

        else if (dirX < 0 && dirY < 0) //left down
        {
            scaling.x = scaling.x - 1;
            scaling.y = scaling.y - 1;
            rotate.z = 0f;
        }

        transform.localScale = scaling;
        transform.rotation = Quaternion.Euler(rotate);
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
