using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Sprite _grayScaleSprite, _collectedSprite;

    public Sprite GrayScaleSprite { get => _grayScaleSprite; set => _grayScaleSprite = value; }
    public Sprite CollectedSprite { get => _collectedSprite; set => _collectedSprite = value; }

    public GameManager gm;
    public int keyId;

    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        dropKey();
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

    private void dropKey()
    {
        if (Input.GetKey(KeyCode.F) && gm.carryingKey)
        {
            Instantiate(Resources.Load("Key"), player.transform.position + new Vector3(2, 1, 0), Quaternion.identity);
            Debug.Log("Avain tiputettu!");
            gm.carryingKey = false;
            //GameObject droppedKey = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //droppedKey.transform.position = player.transform.position + new Vector3(2, 1, 0);
        }
    }
}
