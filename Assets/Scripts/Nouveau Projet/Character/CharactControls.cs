using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactControls : MonoBehaviour
{
    [Header("Sum Stats")]

    [HideInInspector]
    public Vector2 moving;
    [HideInInspector]
    public float lastMovHorizon;
    [HideInInspector]
    public float lastMovVertical;
    [HideInInspector]
    public Vector3 lastMovVector;
    
    [HideInInspector]
    public Vector2 mousePos;

    [Header("Dash")]
    public float dashSpeed;
    public float dashLenght = .8f;
    public float dashCooldown = 3f;
    bool isDashing = false;
    bool CanDash = true; 

    [SerializeField] protected CharactControls cont; 
    [SerializeField] public Rigidbody rb;
    [SerializeField] protected CharacterStats characterStats; 
    [SerializeField] public Animate animate; 
    [SerializeField] public CharacterScriptable CharaData; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cont = GetComponent<CharactControls>();
        animate = GetComponent<Animate>();

        lastMovVector = new Vector3(1f, 0f, 0f);
    }

    public void FixedUpdate()
    {  
        Movement();

        if(Input.GetButtonDown("Fire1") && CanDash == true)
        {
            Debug.Log("I dash");
            StartCoroutine(Dash());
        }
    }

    public void Movement()
    {
        moving.x = Input.GetAxisRaw("Horizontal");
        moving.y = Input.GetAxisRaw("Vertical");

        animate.hoerizontal = moving.x; 

        moving.Normalize();

        rb.velocity = moving * CharaData.MovSpeed; 
    }


    public IEnumerator Dash()
    {
        CanDash = false;
        isDashing = true; 
        rb.velocity = new Vector3(moving.x * dashSpeed, moving.y * dashSpeed, 0f);
        yield return new WaitForSeconds(dashLenght);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        CanDash = true; 
    }

}
