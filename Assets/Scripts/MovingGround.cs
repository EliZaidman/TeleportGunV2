using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;
    public float wRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = new Quaternion
            (gameObject.transform.rotation.x + xRotation, gameObject.transform.rotation.y + yRotation, gameObject.transform.rotation.z + zRotation, gameObject.transform.rotation.w + wRotation);
    }
}
