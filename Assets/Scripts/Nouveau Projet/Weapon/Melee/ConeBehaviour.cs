using UnityEngine;
using System.Collections.Generic;


public class ConeBehaviour : MeleeWeapon
{
    public float duration = 0.5f;
    public float destroyDelay = 0.25f;
    private float timer = 0f;
    private bool destroyScheduled = false;

    private Vector3 initialLocalPosition;
    List<GameObject> markedEnemies;

    //private Rigidbody rigi;
    /*private void Awake()
    {
        //rigi = GetComponent<Rigidbody>();
        //rigi.constraints = RigidbodyConstraints.FreezeRotation;
    }*/
    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float progress = Mathf.Clamp01(timer / duration);

        Vector3 newScale = Vector3.one * (0.5f + 1f * progress);

        transform.localScale = newScale;

        if (progress >= 0.5f && !destroyScheduled)
        {
            Invoke("DestroyObject", destroyDelay);
            destroyScheduled = true;
        }
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
            en.TakeDmg(GetCurrentDamage());
            //Debug.Log("boom");
            markedEnemies.Add(other.gameObject);
        }
    }
    /*public int GetCurrentDamage()
    {
        return stats.currentAttack + weapon.damage;
    }*/
}
