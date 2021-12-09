using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float turn;
    public float jumpForce;
    public GameObject keyPrefab;  

    private float moveInput;
    private float turnInput;
    private bool isOnGround = true;
    private bool gravChange = false;
    private bool gravChangePossible = false;

    private GameManager gm;
    private Rigidbody playerRb;



    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
        playerRb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        
        //Get inputs
        if (isOnGround)
        {
            moveInput = Input.GetAxisRaw("Vertical");
        }
        turnInput = Input.GetAxisRaw("Horizontal");


        //If player presses Space and is on ground, then jump
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gravChange)
        {
            Jump();
        }

        CheckGravChange();

        Move();

        DropKey();
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
            speed = FindObjectOfType<PermanentData>().settings.duckMovementSpeed/2f;
        }
        else if (other.tag == "Finish")
            gm.Exit();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gravity")
        {
            gravChangePossible = false;
            gravChange = false;
            gm.LockGravity(-transform.up);
            speed = FindObjectOfType<PermanentData>().settings.duckMovementSpeed;
        }
        else if (other.tag == "GameOver")
            gm.GameOver("Duck fell out of the world...");
    }

    public void Move()
    {
        //Move and rotate player according to input
        transform.Translate(Vector3.forward * speed * moveInput * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * turnInput * Time.deltaTime);
    }

    public void Jump()
    {
        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }

    public void DropKey()
    {
        //If player presses R and is already carrying key, instantiate a new keyPrefab next to player
        if (Input.GetKey(KeyCode.R) && gm.carryingKey)
        {
            Instantiate(keyPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            gm.carryingKey = false;
        }
    }

    public void CheckGravChange()
    {
        if (gravChangePossible)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (gravChange)
                {
                    gm.LockGravity(-transform.up);
                    playerRb.freezeRotation = true;
                }
                gravChange = !gravChange;
            }

            if (gravChange)
            {
                playerRb.freezeRotation = false;
                gm.ChangeGravity(-transform.up);
            }
        }
    }
}
