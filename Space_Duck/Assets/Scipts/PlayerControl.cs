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
    }

    void Update()
    {
        //Get inputs
        if (isOnGround)
        {
            moveInput = Input.GetAxis("Vertical");
        }
        turnInput = Input.GetAxis("Horizontal");

        //Move and rotate player according to input
        transform.Translate(Vector3.forward * speed * moveInput * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * turnInput * Time.deltaTime);


        //If player presses Space and is on ground, then jump
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gravChange)
        {
            //playerRb.freezeRotation = true;
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

        //Debug.Log(string.Format("{0}, {1}", Physics.gravity, gravChange));

        dropKey();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        playerRb.freezeRotation = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        playerRb.freezeRotation = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gravity")       
            gravChangePossible = true;           
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
        }
        else if (other.tag == "GameOver")
            gm.GameOver("Duck fell out of the world...");
    }


    private void dropKey()
    {
        //If player presses R and is already carrying key, instantiate a new keyPrefab next to player
        if (Input.GetKey(KeyCode.R) && gm.carryingKey)
        {
            Instantiate(keyPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            gm.carryingKey = false;
        }
    }
}
