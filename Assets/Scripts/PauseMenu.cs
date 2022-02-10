using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject Menu;
    public GunManager gunManager;
    public GunMove gunMove;
    public MovementScript movement;
    public GameObject mainMenu;
    public bool insideMenu = false;

    public GameObject character;
    GameObject player;
    public GameObject miniGame;
    private CharacterController cc;

    public GameObject playerCanvas;
    private void Start()
    {
        player = GameObject.Find("Character");
        cc = player.GetComponentInChildren<CharacterController>();

    }
    void Update()
    {
        if (!insideMenu)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                insideMenu = true;
                StartCoroutine(StopGame());
            }
        }


    }

    IEnumerator StopGame()
    {

        yield return new WaitForSeconds(0.2f);
        gunManager.enabled = false;
        gunMove.enabled = false;
        movement.enabled = false;
        //Time.timeScale = 0;

    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gunManager.enabled = true;
        gunMove.enabled = true;
        movement.enabled = true;
        //Time.timeScale = 1;
        Menu.SetActive(false);
        insideMenu = false;


    }

    public void MiniGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gunManager.enabled = true;
        gunMove.enabled = true;
        movement.enabled = true;
        Menu.SetActive(false);
        insideMenu = false;

        cc.enabled = false;
        player.transform.position = miniGame.transform.position;
        cc.enabled = true;
        playerCanvas.SetActive(true);
        gunManager.hasBullets = true;

    }
}
