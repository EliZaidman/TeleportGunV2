using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveSpeed : MonoBehaviour
{
    public MovementScript player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            player.runningSpeed = 50;
            player.walkingSpeed = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            player.runningSpeed = 25;
            player.walkingSpeed = 20f;

        }
    }
}
