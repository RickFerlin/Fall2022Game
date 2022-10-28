using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverBehaviour : MonoBehaviour
{
    [SerializeField] private float speed =10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;
    [SerializeField] private float brakeSpeed = 20f;
    
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
}