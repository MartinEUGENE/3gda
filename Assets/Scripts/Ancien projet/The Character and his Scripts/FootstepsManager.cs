using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FootstepsManager : MonoBehaviour
{

    [SerializeField] EventReference footsteps;
    [SerializeField] GameObject player;
    [SerializeField] CharacterControls character;
    [SerializeField] float rate;

    float time;     


    void PlaySound()
    {
        RuntimeManager.PlayOneShotAttached(footsteps, player);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime; 
        if(character.isMoving == true)
        {
            PlaySound();
            time = 0f; 
        }
    }
}
