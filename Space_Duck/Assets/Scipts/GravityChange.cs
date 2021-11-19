using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public float gravityVal;
    private Rigidbody rb;
    Vector3 gravityDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        gravityDir = new Vector3(0, -90, 0);
        ChangeGravity(gravityDir);
    }

    public void ChangeGravity(Vector3 direction)
    {
        Physics.gravity = gravityVal * direction;
    }
}
