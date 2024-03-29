using UnityEngine;
using System.Collections.Generic;

public class ConeBehaviour : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(1, 1, 1); // Set the target scale here
    public float growthSpeed = 1.0f; // Adjust as needed

    private bool isGrowing = true;

    private float cooldownTimer = 0f;
    private bool destroyScheduled = false;

    private List<GameObject> markedEnemies;

    public WeaponStats weaponStats; // Reference to the WeaponStats object

    protected void Start()
    {
        markedEnemies = new List<GameObject>();
        transform.localScale = Vector3.zero; // Start at zero scale
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= weaponStats.Cooldown && !destroyScheduled)
        {
            Destroy(gameObject);
            destroyScheduled = true;
        }

        if (isGrowing)
        {
            transform.localScale += Vector3.one * growthSpeed * Time.deltaTime;

            if (transform.localScale.x >= targetScale.x &&
                transform.localScale.y >= targetScale.y &&
                transform.localScale.z >= targetScale.z)
            {
                transform.localScale = targetScale;
                isGrowing = false;
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            en.TakeDmg(GetCurrentDamage());
            markedEnemies.Add(other.gameObject);
            Destroy(gameObject);
        }
    }

    public int GetCurrentDamage()
    {
        return weaponStats.Damage; // Accessing damage from WeaponStats
    }
}
