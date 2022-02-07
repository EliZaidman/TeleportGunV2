using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     GameObject bullet;
     GunManager gunManager;
   public AudioSource audiosource;
   public AudioClip Clip;
   
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

        if (collision.gameObject.CompareTag("Red") && gameObject.CompareTag("Red"))
        {
            Debug.Log("Red Trigger");

            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Green") && gameObject.CompareTag("Green"))
        {
            Debug.Log("Green Trigger");
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        {
            Debug.Log("Black Trigger");
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Glass") )
        {
            Destroy(gameObject);
            Debug.Log("Glass Is Glass, And Glass Can Brake");
            //StartCoroutine(DestroyAfter(collision.gameObject));
        }

        if (collision.gameObject.CompareTag("metal"))
        {
            PlayBullet(Clip);
        }
    }
    public void PlayBullet(AudioClip clip)
    {
        audiosource.clip = clip;
        audiosource.Play();
    }
    private void OnTriggerEnter(Collider collision)
    {

    }

    IEnumerator DestroyAfter(GameObject collistionObject)
    {
        Debug.Log("entered Coo");
        yield return new WaitForSeconds(2);
        Destroy(collistionObject);
        Debug.Log("Exited co Coo");

    }
}
