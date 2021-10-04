using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 20.0f;
    private float turn = 100.0f;
    private float jumpForce = 2.0f;
    private float moveInput;
    private float turnInput;

    public Rigidbody rb;

    void Update()
    {
        //Get inputs
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //Move player
        transform.Translate(Vector3.forward * speed * moveInput * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * turnInput * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
}
