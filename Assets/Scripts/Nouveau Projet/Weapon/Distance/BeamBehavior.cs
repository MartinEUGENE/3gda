using UnityEngine;

public class BeamBehavior : MeleeWeapon
{
    public float duration = 0.25f;
    protected override void Start()
    {
        Destroy(gameObject, duration);
        stats = GetComponentInParent<CharacterStats>(); 
        OnSpawn(); 
    }

    protected override void OnSpawn()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Secondary Weapons/Taser_Weapon");
    }

    protected override void Update()
    {
        base.Update();
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
