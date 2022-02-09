using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    //public KeyCode interactKey;
    //public UnityEvent interactAction;
    public Rigidbody rb;
    public float gravitForce;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(0, gravitForce, 0);
    }

    private void OnEnable()
    {
        
    }
    void Update()
    {
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.useGravity = true;
            rb.AddForce(0, gravitForce, 0);
            Debug.Log("in range");

        }
    }
    private void OnTriggerEnter(Collision collision)
    {

        


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = false;
            Debug.Log("not in range");
        }
    }
    public void UseGravity()
    {
        //if (!rb.useGravity)
        //{
            
        //    rb.useGravity = true;
        //}
        //else
            
        rb.useGravity = true;
        rb.AddForce(0, gravitForce, 0);
       
        Debug.Log("inGravity");

    }
}
