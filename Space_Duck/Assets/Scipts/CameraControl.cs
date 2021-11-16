using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    public float rotationSensitivity = 5.0f;

    public float zoomSensitivity = 3.0f;
    private float mouseX;
    private float mouseY;
    private float rotationX;
    private float rotationY;
    private Vector3 nextRotation;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField]
    private float smoothTime = 3.0f;

    [SerializeField]
    private float distance = 3.0f;

    public Transform target;


    private void Start()
    {
        //Make a starting point for the camera so the start of the game is not so awkward
    }

    private void Update()
    {
        //Get mouse input
        mouseX = Input.GetAxis("Mouse X") * rotationSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * rotationSensitivity;

        rotationX += mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, -40, 40);

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        nextRotation = new Vector3(rotationX, rotationY, 0);

        transform.localEulerAngles = currentRotation;

        transform.position = target.position -transform.forward * distance;


        //Zooming
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;

            zoomAmount *= distance * 0.3f;

            distance += zoomAmount * -1f;

            distance = Mathf.Clamp(distance, 1.5f, 100f);
        }
    }
}
