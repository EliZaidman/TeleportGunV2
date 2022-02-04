using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private GameObject player;
    public float jumpForce;
    //public MovementScript MovementScript;

     Vector3 direction;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");

    }

    // Update is called once per frame
    void Update()
    {

    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("inside");
            player.GetComponent<MovementScript>().Push(jumpForce);
        }
    }
}
