using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorControl : MonoBehaviour
{
    //public float pitch = 0f;
    // ce qu'ils on tous en commun
    private bool painted = false;
    public Rigidbody rb;
    public UnityEvent startUp;
    public delegate void OnRaycastHitAction();
    public static event OnRaycastHitAction OnRaycastHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    
                    OnRaycastHit?.Invoke(); // Invoke the event
                }
            }
        }
        // when cliked on trigger paint
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (painted == false)
        //    {
        //        //active la couleur et le script lié? active gravité?
        //        Debug.Log("painted");
        //        painted = true;
        //        rb.useGravity = true; //rajout un truc qui active/toggle un script pour water et autre
        //    }
        //    else { Debug.Log("NO paint"); painted = false; rb.useGravity = false; }

        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (!string.IsNullOrEmpty(hit.transform.gameObject.name))
        //        {
                   

        //        }
        //    }
        //}
    }

    private void HandleRaycastHit()
    {
        //Debug.Log("oui");

        if (painted == false)
        {
            startUp?.Invoke(); //comment trigger wateret autre en séparé
            //ils s'activent tous en meme temps , comment l'empéché
            Debug.Log("painted");
            painted = true;
            rb.useGravity = true; //

        }
        else { Debug.Log("NO paint"); painted = false; 
            //rb.useGravity = false; 
        }

        
    }

    private void OnEnable()
    {
        OnRaycastHit += HandleRaycastHit;
        
    }

    private void OnDisable()
    {
        OnRaycastHit -= HandleRaycastHit;
    }


}
