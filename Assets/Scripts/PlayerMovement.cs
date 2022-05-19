using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float staminaValue;
    [SerializeField] float minStamina;
    [SerializeField] float maxStamina;
    [SerializeField] float staminaCounter;
    [SerializeField] float depsnea = 50f; //отдышка
    [Range(1, 10)] [SerializeField] float smoothSpeed;
    public CharacterController character;
    public float currentSpeed;
    public float usualSpeed = 4f;
    public float speedWhenRun = 7;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    private void Start()
    {
        staminaValue = 100f;
    }
    // Update is called once per frame
    void Update()
    {
        //currentSpeed = speed;
        Movement();
        Stamina();
    }


    private void Stamina()
    {
        if (staminaValue > 100) staminaValue = 100f;
    }

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        character.Move(move * currentSpeed * Time.deltaTime);



        if (Input.GetKey(KeyCode.LeftShift) && staminaValue > 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, speedWhenRun, Time.deltaTime * smoothSpeed);
            staminaValue -= staminaCounter * Time.deltaTime * 6;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, usualSpeed, Time.deltaTime * smoothSpeed);
            // staminaValue += staminaCounter * 2;
            staminaValue += staminaCounter * Time.deltaTime * 6;
        }
        if (staminaValue < 0) staminaValue = 0;

    }


}
