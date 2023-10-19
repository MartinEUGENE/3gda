using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public float that = 0f;
    public float pitch = 0f;

    public float walkspeed = 5.0f;
    public float sensitivty = 2.0f; 

    private Rigidbody rb; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Look()
    {
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivty;
        that += Input.GetAxisRaw("Mouse X") * sensitivty;
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, that, 0);
    }
    void Movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) *  walkspeed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0f, Camera.main.transform.right.x);
        Vector3 ThatDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = ThatDirection; 
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        Look();
    }
}
