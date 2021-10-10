using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameManagerBeta gm;
    public int keyId;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        switch (this.tag)
        {
            case "Key":
                if (Input.GetKey(KeyCode.E))
                {
                    if (!gm.carryingKey)
                    {
                        Destroy(gameObject);
                        gm.carryingKey = true;
                        gm.key = keyId;
                    }
                }
                break;

            case "Energy":
                Destroy(gameObject);
                gm.energy++;
                break;

            case "Duck":
                Destroy(gameObject);
                gm.ducks++;
                break;
        }
        
    }
}
