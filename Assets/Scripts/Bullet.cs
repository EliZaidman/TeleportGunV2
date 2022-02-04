using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     GameObject bullet;
     GunManager gunManager;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
    }
    //public bool IsBulletActive()
    //{
    //    if (gameObject.Equals(isActiveAndEnabled))
    //    {
    //        Debug.Log("ThereIsBullet");
    //        return true;

    //    }

    //    else
    //    {
    //        Debug.Log("NoBullet");
    //        return false;

    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("VelocityWall"))
        {
            Debug.Log("SPEED");
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(10, 10, gunManager.launchVelocity * 100));

        }


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Red") && gameObject.CompareTag("Red"))
        {
            Debug.Log("Red Trigger");

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Green") && gameObject.CompareTag("Green"))
        {
            Debug.Log("Green Trigger");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        {
            Debug.Log("Black Trigger");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
