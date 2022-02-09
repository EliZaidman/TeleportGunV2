using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSounds : MonoBehaviour
{

    public AudioClip WarpIn;
    public AudioClip WarpOut;
    public Collider big;
    void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Red") && gameObject.CompareTag("Red"))
        {
            Debug.Log("Red Trigger");
            StartCoroutine(Warp());
            Destroy(collision.gameObject);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Green") && gameObject.CompareTag("Green"))
        {
            Debug.Log("Green Trigger");
            StartCoroutine(Warp());

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        {
            Debug.Log("Black Trigger");
            StartCoroutine(Warp());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Glass"))
        {
            Destroy(gameObject);
            Debug.Log("Glass Is Glass, And Glass Can Brake");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator Warp()
    {
        big.enabled = false;
        AudioManager.Instance.PlayWorp(WarpIn);
        yield return new WaitForSeconds(2);
        AudioManager.Instance.PlayWorp(WarpOut);
        yield return new WaitForSeconds(2);
        big.enabled = true;
    }
}
