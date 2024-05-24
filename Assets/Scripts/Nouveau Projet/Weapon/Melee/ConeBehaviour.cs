using UnityEngine;
using System.Collections.Generic;


public class ConeBehaviour : MeleeWeapon
{
    public float duration = 0.5f;
    public float destroyDelay = 0.25f;
    private float timer = 0f;
    private bool destroyScheduled = false;

    private Vector3 initialLocalPosition;
  
    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
        initialLocalPosition = transform.localPosition;
    }

    protected override void Update()
    {
        inateCrit = Random.Range(1, 100);

        /*timer += Time.deltaTime;

        float progress = Mathf.Clamp01(timer / duration);

        Vector3 newScale = Vector3.one * (0.5f + 1f * progress);//affect scale par lvl a rajouter

        transform.localScale = newScale;

        if (progress >= 0.5f && !destroyScheduled)
        {
            Invoke("DestroyObject", destroyDelay);
            destroyScheduled = true;
        }*/
    }

    protected override void OnSpawn()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Secondary Weapons/Spray_Weapon"); 
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();

            en.knockDuration = weapon.KnockbackDuration;
            en.knockForce = weapon.Knockback;

            en.TakeDmg(GetCurrentDamage(), hasCrit);
            markedEnemies.Add(other.gameObject);
        }
    }
    
}
