using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaterBehaviour : BroColor
{
    public float conveyorForce;    //Pour les cailloux

    //Variable pour le vecteur de force
    public Vector3 waterVar; 

    private Collider [] woter;
    public FMOD.Studio.EventInstance wa;
    public FMOD.Studio.EventInstance so;

    public LevelManagement level;
    [SerializeField] BroColor col; 
    public CharacterControls chara;

    //[SerializeField] Renderer water; 

    private void Start()
    {
        woter = GetComponentsInChildren<Collider>();

        foreach (var item in woter)
        {
            item.isTrigger = false;
        }
        wa = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Water");
        so = FMODUnity.RuntimeManager.CreateInstance("event:/InteractiveEnvironement/Fall_in_Water");

        col = GetComponent<BroColor>();
        wa.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }


    public override void CustomActivation()
    {
        isActive = true; 
        foreach (var item in woter)
        {
            item.isTrigger = true;
        }
        wa.start();
    }

    public override void CustomDeactivation()
    {
        isActive = false;
        //woter.isTrigger = false;
        Collider[] cols = GetComponentsInChildren<Collider>();
        foreach (var item in woter)
        {
            item.isTrigger = false;
        }
        wa.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


    private void OnTriggerEnter(Collider other)
    {
        bool inside = true;

        if (isActive && inside && other.CompareTag("Player"))
        {
            inside = false;
            so.start();

            Debug.Log("Ah, shinda");
        }


        if(isActive && inside && other.CompareTag("Rock"))
        {
            inside = false;
            Debug.Log("gruuuuuuuuuuuuuuuuu");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActive == true && other.CompareTag("Player"))
        {
            wa.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            level.ButtonStart();
            chara.enabled = false;
            col.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

        if (isActive == true && other.CompareTag("Rock") && !other.CompareTag("Cloud") && !other.CompareTag("Fog") && !other.CompareTag("Ground"))
        {
            other.GetComponent<Rigidbody>().AddForce(waterVar * conveyorForce, ForceMode.Acceleration);
            /*if(other.GetComponent<Rigidbody>().velocity )*/

        }

    }
}

