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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cont = GetComponent<CharactControls>();

        activeSpeed = movSpeed; 
    }

    void FixedUpdate()
    {
        Movement(); 

        if(lastMovHorizon !=0f)
        {
            lastMovHorizon = moving.x;
        }

        if(lastMovVertical != 0f)
        {
            lastMovVertical = moving.z;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Dash();
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeSpeed = movSpeed;
                dashCoolCounter = dashCooldown;
            }

        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }


    void Movement()
    {
        moving.x = Input.GetAxisRaw("Horizontal");
        moving.z = Input.GetAxisRaw("Vertical");
             

        moving.Normalize();

        rb.velocity = moving * activeSpeed; 
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
