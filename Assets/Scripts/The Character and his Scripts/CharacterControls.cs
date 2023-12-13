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

    Vector3 noSpeed;
    private FMOD.Studio.EventInstance steps;


    private Rigidbody rb;
    private GameObject grabbedObject;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Corrected line to get the Rigidbody component
        steps = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Character_Walk");

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sand"))
        {
            steps.setParameterByNameWithLabel("Enviro", "Sand");
        }

        if (other.CompareTag("Ice"))
        {
            steps.setParameterByNameWithLabel("Enviro", "Ice");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        steps.setParameterByNameWithLabel("Enviro", "Normal");
    }

    void PlayThisSound()
    {
        // steps.start();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Character_Walk");
    }

}

