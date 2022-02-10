using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public GameObject character;
    public GameObject player;
    public GameObject gun;
    public GameObject canvas;


    public void LoadGameClick()
    {
        player.SetActive(true);
        gun.SetActive(true);
        canvas.SetActive(false);
        character.GetComponent<MovementScript>().enabled = true;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SpeedRun");
    }


}