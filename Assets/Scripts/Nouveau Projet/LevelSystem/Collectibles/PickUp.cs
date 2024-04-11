using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    protected CharacterStats targ;
    public float speed;
    public float life;
    Vector2 intialPos;

    [System.Serializable]
    public struct BobbingAnim
    {
        public float frequency;
        public Vector2 direction;     
    }

    public BobbingAnim bobb = new BobbingAnim
    {
        frequency = 2f,    direction = new Vector2(0, 0.5f)
    }; 


    [Header("Bonus")]
    public int exp;
    public int hp;

    public virtual void Start()
    {
        intialPos = transform.position; 
    }

    protected virtual void Update()
    {
        if(targ)
        {           
            Vector2 dir = targ.transform.position - transform.position;
            if(dir.sqrMagnitude > speed * speed *Time.deltaTime)
            {
                transform.position += (Vector3)dir * speed * Time.deltaTime; 
            }

            else
            {
                Destroy(gameObject);
            }
        }

        else
        {
            transform.position = intialPos + bobb.direction * Mathf.Sin(Time.time * bobb.frequency); 
        }
    }

    public virtual bool Collect(CharacterStats chara, float speed, float life = 0f)
    {
        if (!this.targ)
        {
            this.targ = chara;
            this.speed = speed;
            if (life > 0f) this.life = life;

            Destroy(gameObject, Mathf.Max(0.01f, life));
            return true; 
        }        
        
        return false;
    }


    protected virtual void OnDestroy()
    {
        if (!targ) return;
        if (exp != 0)
        {
            targ.IncreaseExperience(exp);
            FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Collectibles/Exp/ExpCollect");
        }
        if(hp != 0) targ.Healing(hp);

    }

}
