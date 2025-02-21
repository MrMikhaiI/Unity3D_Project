using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MonoBehaviour
{
    //public float speed;
    //private Rigidbody _rb;

    //private void Awake()
    //{
    //    _rb = GetComponent<Rigidbody>();
    //}

    //private void Move(float direction)
    //{
    //    Vector3 newVelocity = _rb.velocity;
    //    newVelocity.z = direction * speed;
    //    _rb.velocity = newVelocity;
    //}

    //private void Update()
    //{
    //    float direction = Input.GetAxis("Horizontal");
    //    Move(direction);
    //    //Move(Input.GetAxis("Horizontal"));

    //}

    private Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }
}
