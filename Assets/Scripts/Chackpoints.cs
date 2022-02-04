using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chackpoints : MonoBehaviour
{
    public GameObject chackpoint;
    private GameObject player;
    private CharacterController cc;
    

    private void Start()
    {
        player = GameObject.Find("Character");
        cc = player.GetComponentInChildren<CharacterController>();

    }
    private void Update()
    {



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER! Trigger");
            cc.enabled = false;
            player.transform.position = chackpoint.transform.position;
            cc.enabled = true;
        }
    }

}
