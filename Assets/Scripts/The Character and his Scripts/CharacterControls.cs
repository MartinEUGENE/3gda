using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public float pitch = 0f;
    public float walkspeed = 5.0f;
    public float sensitivity = 3.0f;
    public float grabRange = 5.0f;
    public float liftSpeed = 2.0f; // Adjust the speed of lifting

    private Rigidbody rb;
    private GameObject grabbedObject;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Look()
    {
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 rotatedDirection = transform.TransformDirection(direction);

        rb.MovePosition(transform.position + rotatedDirection * walkspeed * Time.deltaTime);
    }

    void GrabObject()
    {
        if (Input.GetMouseButtonDown(1) && grabbedObject == null) // Right mouse button and no object grabbed
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, grabRange))
            {
                if (hit.transform.CompareTag("Rock") || hit.transform.CompareTag("Key"))
                {
                    // Check if the object is active before grabbing
                    RockBehaviour rockBehavior = hit.transform.GetComponent<RockBehaviour>();
                    if (rockBehavior != null && rockBehavior.isActive)
                    {
                        // Grab the object
                        grabbedObject = hit.transform.gameObject;
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                        grabbedObject.transform.SetParent(transform);
                    }
                }
            }
        }

        if (grabbedObject != null)
        {
            // Lift the grabbed object based on mouse movement
            float liftAmount = Input.GetAxisRaw("Mouse Y") * liftSpeed * Time.deltaTime;
            grabbedObject.transform.Translate(Vector3.up * liftAmount);
        }

        if (Input.GetMouseButtonUp(1) && grabbedObject != null)
        {
            // Release the object
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
        }
    }

    void Update()
    {
        Look();
        GrabObject();
    }

    private void FixedUpdate()
    {
        Movement();
    }
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

/*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }*/