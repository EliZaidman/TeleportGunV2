using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkCollison : MonoBehaviour
{
    CharacterController characterController;
    public AudioClip metalFloor;
    public AudioClip NormalFloor;
    public AudioClip ChainFloor;
    bool isWalking = false;
    private void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
        
    }
     
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "metal")
        {
            Debug.Log("test");
            StartCoroutine(FootSound());
        }
        if (collision.gameObject.tag == "NormalFloor")
        {
            Debug.Log("test");
            StartCoroutine(NormalSound());
        }
        if (collision.gameObject.tag == "ChainFloor")
        {
            Debug.Log("test");
            StartCoroutine(ChainSound());
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "metal")
        {
            Debug.Log("test");
            StartCoroutine(FootSound());
        }
        if (collision.gameObject.tag == "NormalFloor")
        {
            Debug.Log("test");
            StartCoroutine(NormalSound());
        }
        if (collision.gameObject.tag == "ChainFloor")
        {
            Debug.Log("test");
            StartCoroutine(ChainSound());
        }
    }
    public IEnumerator FootSound()
    {
        Debug.Log("out");
        isWalking = true;
        if (characterController.isGrounded && isWalking)
        {
            Debug.Log("in Metal");

            AudioManager.Instance.PlayPlayer(metalFloor);
        }
        yield return new WaitForSeconds(3);
        isWalking = false;
        AudioManager.Instance.PlayerSource.Stop();

    }
    public IEnumerator ChainSound()
    {
        
        isWalking = true;
        if (characterController.isGrounded && isWalking)
        {
            Debug.Log("in Chain");

            AudioManager.Instance.PlayPlayer(ChainFloor);
        }
        yield return new WaitForSeconds(3);
        isWalking = false;
        AudioManager.Instance.PlayerSource.Stop();
    }
    public IEnumerator NormalSound()
    {
        
        isWalking = true;
        if (characterController.isGrounded && isWalking)
        {
            Debug.Log("in Normal");

            AudioManager.Instance.PlayPlayer(NormalFloor);
        }
        yield return new WaitForSeconds(3);
        isWalking = false;
        AudioManager.Instance.PlayerSource.Stop();
    }
}
