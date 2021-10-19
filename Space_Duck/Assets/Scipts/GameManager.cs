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
    private float defGravity, changeGravity;

    private void Start()
    {
        Physics.gravity = -Vector3.up * defGravity;
    }

    public void ChangeGravity(Vector3 dir)
    {
        Physics.gravity = dir * changeGravity;
    }

    public void LockGravity(Vector3 dir)
    {
        Physics.gravity = dir * defGravity;
    }
}
