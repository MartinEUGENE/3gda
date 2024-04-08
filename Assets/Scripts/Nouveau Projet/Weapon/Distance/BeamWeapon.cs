using UnityEngine;

public class BeamWeapon : WeaponSystem
{
    public GameObject beamPrefab;
    private Transform playerTransform;
    private float lastDirection = 1f; // Last direction taken by the player (1 for right, -1 for left)

    protected override void Start()
    {
        base.Start();
        playerTransform = transform.parent.transform;
    }

    protected override void Update()
    {
        base.Update();
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
        float direction = Mathf.Sign(playerTransform.localScale.x);

        // Calculate the position to instantiate the beam
        Vector3 beamPosition = playerTransform.position + Vector3.right * direction;

        // Determine if the prefab needs to be flipped based on the last direction
        bool flipPrefab = lastDirection != direction;

        // Adjust the rotation of the instantiated prefab
        Quaternion rotation = Quaternion.identity;
        if (flipPrefab)
        {
            rotation = Quaternion.Euler(0f, 180f, 0f); // Rotate 180 degrees around the y-axis
        }

        // Instantiate the beam prefab
        GameObject beam = Instantiate(beamPrefab, beamPosition, rotation);

        // Update the last direction taken by the player
        lastDirection = direction;

        // Set the beam's direction based on the player's facing direction
        BeamBehavior beamBehavior = beam.GetComponent<BeamBehavior>();
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
