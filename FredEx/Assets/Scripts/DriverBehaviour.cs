using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverBehaviour : MonoBehaviour
{
    [SerializeField] private float speed =10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;
    [SerializeField] private float brakeSpeed = 20f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float slowSpeed = 6f;
    
    private int steerValue;
    private bool brakesEngaged;
    
    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;
        
        transform.Rotate(0f, 0f, steerValue * turnSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (brakesEngaged)
        {
            Brakes(true);
        }
    }

    public void Steer(int value)
    {
        steerValue = value;
    }

    public void Brakes(bool set)
    {
        if (speed > 2)
        {
            speed -= brakeSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (speed > slowSpeed)
        {
            speed = slowSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost") && speed < boostSpeed)
        {
            speed = boostSpeed;
        }
    }
}