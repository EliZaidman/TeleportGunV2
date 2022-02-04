using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGravity : MonoBehaviour
{
   public Rigidbody rb;
    public float gravitForce;
    public AudioClip flyingobject;
    private void Awake()
    {
        rb.GetComponent<Rigidbody>();
    }
    public void UseGravity()
    {
        if (!rb.useGravity)
        {
            rb.useGravity = true;
        }
        else
        rb.useGravity = false;
        rb.AddForce(0, gravitForce, 0);
        
    }
   
}
