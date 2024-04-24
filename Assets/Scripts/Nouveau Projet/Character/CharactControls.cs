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
    public Vector2 lastMovVector;
    
    [HideInInspector]
    public Vector2 mousePos;

    [Header("Dash")]
    public float dashSpeed;
    public float dashLenght = .8f;
    public float dashCooldown = 3f;
    bool isDashing = false;
    bool CanDash = true; 

    [SerializeField] protected CharactControls cont; 
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] protected CharacterStats characterStats; 
    [SerializeField] public Animate animate; 
    //[SerializeField] public CharacterScriptable CharaData; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cont = GetComponent<CharactControls>();
        animate = GetComponent<Animate>();

        lastMovVector = new Vector2(1f, 0f);
    }


    private void Update()
    {
        InputManagement();
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
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        rb.velocity = moving * characterStats.currentSpeed; 
    }

    void InputManagement()
    {
        if(GameManager.instance.isGameOver)
        {
            return; 
        }

        moving.x = Input.GetAxisRaw("Horizontal");
        moving.y = Input.GetAxisRaw("Vertical");

        moving.Normalize();

        if(moving.x != 0)
        {
            lastMovHorizon = moving.x; 
        }

        if (moving.y != 0)
        {
            lastMovHorizon = moving.y;
        }
    }


    public IEnumerator Dash()
    {
        CanDash = false;
        isDashing = true; 
        rb.velocity = new Vector2(moving.x * dashSpeed, moving.y * dashSpeed);
        yield return new WaitForSeconds(dashLenght);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        CanDash = true; 
    }

}
