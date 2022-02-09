using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTORY : MonoBehaviour
{
    Collider first;
    Collider second;
    private void Start()
    {
        first = gameObject.GetComponents<Collider>()[0];
        second = gameObject.GetComponents<Collider>()[2];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Blue")
        {
            first.enabled = false;
            second.enabled = false;
        }


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Red" || collision.gameObject.tag == "Green")
        {
            Destroy(collision.gameObject);
        }

        if (true)
        {

        }
    }
}
