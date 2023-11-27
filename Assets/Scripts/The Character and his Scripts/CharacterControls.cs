using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public float pitch = 0f;
    public float walkspeed = 5.0f;
    public float sensitivity = 3.0f;

    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Corrected line to get the Rigidbody component
        
    }

    void Look()
    {
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * sensitivity, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    void Movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * walkspeed;
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 ThatDirection = (forward * axis.x + right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = ThatDirection;

    }

    /*void PaintWorld()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (!string.IsNullOrEmpty(hit.transform.gameObject.name))
                {
                    //Debug.Log("Object Name: " + hit.transform.gameObject.name);
                }
            }
        }
    }*/

    void Update()
    {
        Look();

        //PaintWorld();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }

    private void FixedUpdate()
    {
        Movement();
    }
}

