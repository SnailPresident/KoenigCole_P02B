﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem flash = null;
    [SerializeField] AudioClip bang = null;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    [SerializeField] Slider healthBar;
    public float playerHealth = 100f;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    [SerializeField] AudioClip dieSound = null;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 18f;
        }
        else
        {
            speed = 12f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioHelper.PlayClip2D(bang, 1);
            flash.Play();
        }

        if (playerHealth <= 0)
        {
            AudioHelper.PlayClip2D(dieSound, .25f);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneLoader.LoadScene("MainMenu");
        }

        healthBar.value = playerHealth;
    }

    private void Start()
    {
        healthBar.maxValue = playerHealth;
        healthBar.minValue = 0;
    }
}
