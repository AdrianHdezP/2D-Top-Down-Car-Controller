using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerPC : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float acelerationPower = 10;
    [SerializeField] private float steeringPower = 10;

    private float speed;
    private float steeringAmount;
    private float direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Inputs();
        DirectionAndRotation();
        Movement();
    }

    private void Inputs()
    {
        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * acelerationPower;
    }

    private void DirectionAndRotation()
    {

        // Direction: Si los vectores apuntan a la misma direccion da un valor positivo y si apuntan en otra da un valor negativo
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));

        // Rotation
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;
    }

    private void Movement()
    {
        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }
}
