using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public float gravityVal;
    Vector3 gravityDir;

    private void Update()
    {
        gravityDir = -transform.up;
        ChangeGravity(gravityDir);
    }

    public void ChangeGravity(Vector3 direction)
    {
        Physics.gravity = gravityVal * direction;
    }
}
