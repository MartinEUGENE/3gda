using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : BroColor
{
    public GameObject Wind;
    private FMOD.Studio.EventInstance ventilator;
    private FMOD.Studio.EventInstance ventilation;
    private FMOD.Studio.EventInstance inactEvent;


    public WindBehav windSound; 

    //GameObject storeWind;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Wind.SetActive(false);

        ventilator = FMODUnity.RuntimeManager.CreateInstance("event:/InactiveEnvironement/Inactive_Ventilator");
        ventilation = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Ventilator");
        inactEvent = FMODUnity.RuntimeManager.CreateInstance("event:/AllMixerEvents/InactiveMix/InactiveObjM");
        

        ventilator.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        ventilation.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

        ventilator.start();
        inactEvent.start();
    }

     void Update()
     {
        ventilator.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        ventilation.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
     }

    public override void CustomActivation()
    {
        isActive = true;
        Wind.SetActive(true);

        ventilator.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        ventilation.start();

        windSound.wind.start();
        FMODUnity.RuntimeManager.PlayOneShot("event:/AllMixerEvents/ActiveMix/ActiveMixing");
    }

    public override void CustomDeactivation()
    {
        Wind.SetActive(false);  
        isActive = false;

        ventilator.start();
        ventilation.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        windSound.wind.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FMODUnity.RuntimeManager.PlayOneShot("event:/AllMixerEvents/InactiveMix/InactiveMixing");
    }

}
