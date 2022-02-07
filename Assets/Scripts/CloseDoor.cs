using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject closeDoor;
    public AudioClip doorSound;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("inside");

            closeDoor.SetActive(true);
            AudioManager.Instance.Play(doorSound);
        }
    }
}
