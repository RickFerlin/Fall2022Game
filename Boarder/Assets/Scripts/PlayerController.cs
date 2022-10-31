using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float boostSpeed = 3f;
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float jumpAmount = 5f;
    [SerializeField] private AudioClip jumpSFX;

    Rigidbody2D rb2d;
    private SurfaceEffector2D surfaceEffector2D;
    public bool isGrounded;
    
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
        Jump();
        TouchTorque();
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed += boostSpeed * Time.deltaTime;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            GetComponent<AudioSource>().PlayOneShot(jumpSFX);
            isGrounded = false;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    private void TouchTorque()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > .1f)
            {
                rb2d.AddTorque(torqueAmount);
            }
            else if (mousePos.x < -.1f)
            {
                rb2d.AddTorque(-torqueAmount);
            }
        }
    }
}
