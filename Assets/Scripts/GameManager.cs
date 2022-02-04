using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject closeDoor;

    private void Start()
    {
        
    }
    private void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("inside");
            
            closeDoor.SetActive(true);
        }
    }
    
}
