using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Animation shootAnim;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Entered PLayer");
        }

        if (true)
        {
            //TEST
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TEST
    }
}
