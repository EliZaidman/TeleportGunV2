using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public GameObject player;
    public GameObject gun;
    public GameObject canvas;
    public void LoadGameClick()
    {
        player.SetActive(true);
        gun.SetActive(true);
        canvas.SetActive(false);
        player.GetComponent<MovementScript>().gunManager = gun.GetComponent<GunManager>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SpeedRun");
    }
}