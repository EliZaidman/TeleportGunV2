using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTORY : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Red" || collision.gameObject.tag == "Green")
        {
            Destroy(collision.gameObject);
        }
    }
}
