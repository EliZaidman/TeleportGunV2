using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller; 
    //public Rigidbody rb;
    public Transform player;
    public float walkSpeed = 5f;
    public float moveSpeed = 12f;
    public float runSpeed = 16f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float relativeJumpHeight = 5.5f;
    float posX;
    float PosY;
    float PosZ;
    float maxJumpHeight;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 moveDirection;
    Vector3 velocity;
    bool isGrounded;
    bool isJumping;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        posX = player.position.x;
        PosY = player.position.y;
        PosZ = player.position.z;
        maxJumpHeight = PosY + relativeJumpHeight;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }
        if (isJumping)
        {
            if (PosY >= maxJumpHeight)
            {
                isJumping = false;
            }
        }
        if (isGrounded && velocity.y < 2f)
        {
            if (isJumping == false)
            {
                velocity.y = -2f;
            }
        }
    }
}
