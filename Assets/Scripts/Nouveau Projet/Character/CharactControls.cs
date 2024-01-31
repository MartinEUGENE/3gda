using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactControls : MonoBehaviour
{
    [Header("Sum Stats")]

    private Vector3 moving;
    public float movSpeed = 5f;
    private float activeSpeed;

    [Header("Dash")]

    public float dashSpeed;
    private float dashCounter;
    private float dashCoolCounter;

    public float dashLenght = .8f;
    public float dashCooldown = 3f;

    [Header("Health")]
    public int maxHP = 100; 
    public int currentHP = 0;

    [SerializeField] CharactControls cont; 
    [SerializeField] Rigidbody rb;
    [SerializeField] FirstWeapon weep; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cont = GetComponent<CharactControls>();
        currentHP = maxHP;

        activeSpeed = movSpeed; 
    }

    void FixedUpdate()
    {
        Movement(); 
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


    void Death()
    {
        cont.enabled = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Bullet"))
        {
            currentHP -= 10; 
        }

        if(currentHP <= 0)
        {
            Death(); 
        }

    }

}
