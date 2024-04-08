using UnityEngine;

public class BeamWeapon : WeaponSystem
{
    public GameObject beamPrefab; 
    private Transform playerTransform;


    protected override void Start()
    {
        base.Start();
        playerTransform = transform.parent.transform;
    }

    protected override void Update()
    {
        base.Start();
    }

    protected override void Shoot()
    {
        base.Shoot();
        if (playerTransform == null || beamPrefab == null)
        {
            Debug.LogError("Player transform or beam prefab is not set!");
            return;
        }

        // Get the direction the player is facing (based on scale)
        float direction = playerTransform.localScale.x;

        // Calculate the position to instantiate the beam
        Vector3 beamPosition = playerTransform.position + Vector3.right * direction;
        GameObject beam = Instantiate(beamPrefab, beamPosition, Quaternion.identity);

        // Set the beam's direction based on the player's facing direction
        BeamBehavior beamBehavior = beam.GetComponent<BeamBehavior>();

        Debug.Log("bean");
        if (beamBehavior != null)
        {
            beamBehavior.SetDirection(direction);
        }
        else
        {
            Debug.LogError("Beam prefab is missing BeamBehavior component!");
        }
    }
}
