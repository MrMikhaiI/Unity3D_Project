using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Autorun : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        Vector3 newVelocity = _rb.velocity;
        newVelocity.z = speed;
        _rb.velocity = newVelocity;
    }
}
