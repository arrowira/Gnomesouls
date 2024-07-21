using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;
    [SerializeField]
    private float mouseSensitivity = 100.0f;
    [SerializeField]
    private Transform horizontalEmpty;


    [SerializeField]
    private Animator anm;

    private Vector3 velocity;
    private bool isGrounded;

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Vector3 currentRotation = transform.localEulerAngles;
            Vector3 targetRotation = horizontalEmpty.localEulerAngles;

            // Set only the y-axis rotation to match the target
            transform.localRotation = Quaternion.Euler(currentRotation.x, targetRotation.y, currentRotation.z);
            anm.SetBool("isWalking", true);
            anm.SetBool("isIdle", false);
        }
        else
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isIdle", true);
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
    }
}
