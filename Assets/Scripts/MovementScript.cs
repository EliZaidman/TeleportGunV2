using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class MovementScript : MonoBehaviour
{
    GunManager gunManager;

    public Collider playerCollider;

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit;
    public Slider glideSlider;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    [HideInInspector]
    public float lookXLimitDefult;

    public AudioClip footStepSound;
    public float footStepDelay;

    private float nextFootstep = 0;


    [HideInInspector]
    public bool canMove = true;
    public float speed = 3.0F;
    public float rotateSpeed = 100.0F;


    public AudioClip jetSound;
    public AudioClip jumpSound;

    public AudioClip overHeat;

   


    public bool jetIsPlaying = false;

    void Start()
    {
        gunManager = GetComponentInChildren<GunManager>();

        playerCollider = GameObject.Find("Player").GetComponent<Collider>();
        glideSlider.value = 1;
        characterController = GetComponent<CharacterController>();

        lookXLimitDefult = lookXLimit;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;

            AudioManager.Instance.PlayPlayer(jumpSound);
        }
        else
        {
            moveDirection.y = movementDirectionY;

        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (!gunManager.isStuck)
        {

            if (Input.GetKey(KeyCode.F) && glideSlider)
            {
                glideSlider.gameObject.SetActive(true);
                glideSlider.value -= 0.3F * Time.deltaTime;
                JetSound();
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    glideSlider.value -= 0.4F * Time.deltaTime;
                }
                if (glideSlider.value == 0)
                {
                    glideSlider.gameObject.SetActive(false);
                }
                
            }
        }

        if (/*Input.GetKeyUp(KeyCode.F) && */characterController.isGrounded)
        {
            glideSlider.value = 1;
            glideSlider.gameObject.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(StopJet(0.8f));   
        }

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (Input.GetKey(KeyCode.F) && glideSlider.value > 0)
        {
            if (gravity > 1)
            {
                moveDirection.y = jumpSpeed / 100;
                gravity = 1;

            }

            if (gravity == 1)
            {
                gravity = 1;
            }

        }
        else
        {
            gravity = 20f;
        }



        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && characterController.isGrounded && !Input.GetKey(KeyCode.F))
        {
            nextFootstep -= Time.deltaTime;
            if (isRunning && characterController.isGrounded)
            {
                footStepDelay = 0.3f;
                if (nextFootstep <= 0)
                {
                    gunManager.shootAnim.Play("Running");
                    GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
                    nextFootstep += footStepDelay;
                }
            }
            else
            {
                footStepDelay = 0.5f;
                if (nextFootstep <= 0)
                {
                    //gunManager.shootAnim.Play("Walking");
                    GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
                    nextFootstep += footStepDelay;
                }
            }

        }

        //if (!jetIsPlaying)
        //{
        //    AudioManager.Instance.PlayerSource.Stop();
        //}


    }
    private void FixedUpdate()
    {
        // Move the controller
        //Physics.SyncTransforms();
        characterController.Move(moveDirection * Time.fixedDeltaTime);
    }
    public void Push(float jumpForce)
    {

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Debug.Log("allah");
        moveDirection.y = jumpSpeed * jumpForce;

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

    }

    public void Throw()
    {


        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        gameObject.GetComponent<CharacterController>().SimpleMove(forward * curSpeed);

    }

    private void JetSound()
    {
        AudioManager.Instance.HoverSource.Stop();
        if (glideSlider && !jetIsPlaying)
        {
            AudioManager.Instance.PlayPlayer(jetSound);
        }
        jetIsPlaying = true;

    }

    IEnumerator StopJet(float waitTime)
    {
        yield return new WaitForSeconds(0.3f);
        AudioManager.Instance.PlayHover(overHeat);
        yield return new WaitForSeconds(waitTime);
        jetIsPlaying = false;
    }
}