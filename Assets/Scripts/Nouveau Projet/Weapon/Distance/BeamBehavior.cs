using UnityEngine;

public class BeamBehavior : MeleeWeapon
{
    public float duration = 2f; // Duration of the beam
    private float timer = 0f;

    protected override void Start()
    {
        base.Start();
         timer += Time.deltaTime;

        // If the duration is over, destroy the beam
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    protected override void Update()
    {
        inateCrit = Random.Range(1, 100);

    }
        public void SetDirection(float direction)// Method to set the direction of the beam
    {
        // Adjust the beam's scale based on the direction
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(direction); // Set the scale based on the sign of the direction
        transform.localScale = scale;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            if (en != null)
            {
                en.TakeDmg(GetCurrentDamage(), hasCrit);
                // Debug.Log(GetCurrentDamage());
            }
        }
    }

}
