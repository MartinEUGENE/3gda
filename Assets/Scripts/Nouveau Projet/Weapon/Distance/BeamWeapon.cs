using UnityEngine;

public class BeamWeapon : WeaponSystem
{
    public GameObject beamPrefab;
    private Transform playerTransform;
    private Vector3 lastPosition;
    private int choice;

    protected override void Start()
    {
        base.Start();
        playerTransform = transform.parent.transform;
        lastPosition = playerTransform.position;
    }

    protected override void Update()
    {
        base.Update();

        Vector3 currentPosition = playerTransform.position;

        if (currentPosition.x < lastPosition.x)
        {
            choice = -1;
            //Blast(-1); 
        }
        else if (currentPosition.x > lastPosition.x)
        {
            choice = 1;
            //Blast(1); 
        }
        lastPosition = currentPosition;
    }

    protected override void Shoot()
    {
        base.Shoot();
        if(weaponData.Quantity == 2)//
        {
            Blast(1);
            Blast(-1);
        }
        else
        {
            Blast(choice);
        }
        
    }

    private void Blast(int direction)
    {
        Vector3 beamPosition = playerTransform.position + Vector3.right * direction;
        GameObject beam = Instantiate(beamPrefab, beamPosition, Quaternion.identity, playerTransform);

        if (direction < 0)
        {
            beam.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
