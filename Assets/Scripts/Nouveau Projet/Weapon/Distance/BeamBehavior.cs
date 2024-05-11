using UnityEngine;

public class BeamBehavior : MeleeWeapon
{
    public float duration = 0.25f;
    private float timer = 0f;

    protected override void Update()
    {
        base.Update(); // Call the base class Update method if needed

        // Increment timer
        timer += Time.deltaTime;

        // If the duration is over, destroy the beam
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(float direction)
    {
        // Adjust the beam's scale based on the direction
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(direction); // Set the scale based on the sign of the direction
        transform.localScale = scale;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            if (en != null)
            {
                en.TakeDmg(GetCurrentDamage(), hasCrit);

                en.knockDuration = weapon.KnockbackDuration;
                en.knockForce = weapon.Knockback;

                // Debug.Log(GetCurrentDamage());
            }
        }
    }
}
