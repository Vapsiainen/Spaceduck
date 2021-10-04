using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float turn;
    private float moveInput;
    private float turnInput;
    public float jumpForce;

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
