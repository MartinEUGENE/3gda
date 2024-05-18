using UnityEngine;

public class BeamWeapon : WeaponSystem
{
    public GameObject beamPrefab;
    private Transform playerTransform;
    private Vector3 lastPosition;
    private int choice;
    private Camera cam;
    public bool LvlMax;

    protected override void Start()
    {
        base.Start();
        playerTransform = transform.parent.transform;
        lastPosition = playerTransform.position;
        cam = Camera.main;
    }

    protected override void Update()
    {
        base.Update();
        Vector3 WorldPos = cam.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y,10f));

        Vector3 currentPosition = playerTransform.position;

        if (WorldPos.x < currentPosition.x )
        {
            choice = -1;
            //Blast(-1); 
            Debug.Log("gauche");
        }
        else if (WorldPos.x  > currentPosition.x )
        {
            choice = 1;
            //Blast(1); 
            Debug.Log("droite");
        }
        lastPosition = currentPosition;
    }

    protected override void Shoot()
    {
        base.Shoot();
        Blast(choice);
    }

    private void Blast(int direction)
    {
        
        if(!LvlMax)
        {
            Vector3 beamPosition = playerTransform.position + Vector3.right * direction;
            GameObject beam = Instantiate(beamPrefab, beamPosition, Quaternion.identity, playerTransform);
            if (direction < 0)
            {
            beam.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        else
        {
            Vector3 beamPosition2 = playerTransform.position + Vector3.right * 1;
            Vector3 beamPosition3 = playerTransform.position + Vector3.right * -1;
            GameObject beam2 = Instantiate(beamPrefab, beamPosition2, Quaternion.identity, playerTransform);
            GameObject beam3 = Instantiate(beamPrefab, beamPosition3, Quaternion.identity, playerTransform);
            beam3.transform.localScale = new Vector3(-1, 1, 1);
        }


    }
}
