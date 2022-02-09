using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class GlobalParameterSetByName : MonoBehaviour
{
   public EventInstance Ambience;

    private void Start()
    {
        Ambience = RuntimeManager.CreateInstance("event:/Chain");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Debug.Log("inside1");
        Ambience.start();

        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Chain Fade", 0f);
    }
}
