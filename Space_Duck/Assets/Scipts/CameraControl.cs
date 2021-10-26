using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform player;
    public Transform cam;

    public float rotateSpeed;
    public float zoomSpeed;

    private void Start()
    {
        //Locking camera rotation point to player center
        transform.position = player.position;
    }

    void Update()
    {
        //Rotating camera around player
        transform.Rotate(Vector3.right * Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * -rotateSpeed * Time.deltaTime);
        cam.LookAt(player);

        //Move camera closer or away
        cam.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime);
    }
}
