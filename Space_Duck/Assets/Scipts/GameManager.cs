using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int energy;
    public int key;
    public bool carryingKey = false;
    public int ducks;

    [SerializeField]
    float gravity;
    float gravityChange;

    private void Start()
    {
        Physics.gravity = -Vector3.up * gravity;
    }

    public void ChangeGravity(Vector3 dir)
    {
        Physics.gravity = dir * gravityChange;
    }

    public void LockGravity(Vector3 dir)
    {
        Physics.gravity = dir * gravity;
    }
}
