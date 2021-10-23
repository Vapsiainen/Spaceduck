using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float turn;
    public float jumpForce;

    private float moveInput;
    private float turnInput;
    private bool isOnGround = true;
    private bool gravChange = false;
    private bool gravChangePossible = false;
    GameManager gm;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gm = GameObject.Find("Game manager").GetComponent<GameManager>();
    }

    void Update()
    {
        //Get inputs
        if (isOnGround)
        {
            moveInput = Input.GetAxis("Vertical");
        }
        turnInput = Input.GetAxis("Horizontal");

        //Move player
        transform.Translate(Vector3.forward * speed * moveInput * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * turnInput * Time.deltaTime);

        //If player presses Space and is on ground, then jump
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gravChange)
        {
            playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (gravChangePossible)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (gravChange)
                {
                    gm.LockGravity(-transform.up);
                    Debug.Log("test");
                }
                gravChange = !gravChange;
            }

            if (gravChange)
            {
                gm.ChangeGravity(-transform.up);
            }
        }

        Debug.Log(string.Format("{0}, {1}", Physics.gravity, gravChange));
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gravity")
        {
            gravChangePossible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gravity")
        {
            gravChangePossible = false;
            gravChange = false;
            gm.LockGravity(-transform.up);
        }
    }
}
