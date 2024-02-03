using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactControls : MonoBehaviour
{
    [Header("Sum Stats")]

    [HideInInspector]
    public Vector3 moving;
    [HideInInspector]
    public float lastMovHorizon;
    [HideInInspector]
    public float lastMovVertical;
    [HideInInspector]
    public Vector3 lastMovVector;



    public float movSpeed = 5f;
    private float activeSpeed;

    [Header("Dash")]

    public float dashSpeed;
    private float dashCounter;
    private float dashCoolCounter;

    public float dashLenght = .8f;
    public float dashCooldown = 3f;



    [SerializeField] CharactControls cont; 
    [SerializeField] Rigidbody rb;
    [SerializeField] FirstWeapon weep;
    [SerializeField] CharacterStats characterStats; 
    [SerializeField] public Animate animate; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cont = GetComponent<CharactControls>();
        animate = GetComponent<Animate>();

        activeSpeed = movSpeed;
        lastMovVector = new Vector3(-1f, 0f, 0f);
    }

    public void FixedUpdate()
    {
        Movement(); 

        if(lastMovHorizon !=0f)
        {
            lastMovHorizon = moving.x;
            lastMovVector = new Vector3(moving.x, 0f, 0f);
        }

        if(lastMovVertical != 0f)
        {
            lastMovVertical = moving.y;
            lastMovVector = new Vector3(0f, moving.y, 0f);

        }

        if(moving.x != 0f && moving.y != 0f)
        {
            lastMovVector = new Vector3(moving.x, moving.y, 0f);
        }
    }

    /*private void Update()
    {
    }*/


    public void Movement()
    {
        moving.x = Input.GetAxisRaw("Horizontal");
        moving.y = Input.GetAxisRaw("Vertical");

        animate.hoerizontal = moving.x; 

        moving.Normalize();

        rb.velocity = moving * movSpeed; 
    }


    void Dash()
    {
        if (dashCounter <= 0 && dashCoolCounter <= 0)
        {
            activeSpeed = dashSpeed;
            dashCounter = dashLenght;
        }
    }

}
