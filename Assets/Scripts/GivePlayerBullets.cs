using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlayerBullets : MonoBehaviour
{
    public AudioClip getBullets;
    public GameObject canvas;
    public GunManager gunManager;
    private void OnTriggerEnter(Collider other)
    {
        if (!gunManager.hasBullets)
        {
        if (other.gameObject.layer == 3)
        {
            AudioManager.Instance.PlayWorp(getBullets);
            canvas.SetActive(true);
            gunManager.hasBullets = true;
            
            //Destroy(this);
        }
        }


    }
}
