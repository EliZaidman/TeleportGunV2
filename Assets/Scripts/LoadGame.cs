using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public void LoadGameClick()
    {
        player.SetActive(true);
        canvas.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SpeedRun");
    }
}