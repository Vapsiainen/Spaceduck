using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Sprite _grayScaleSprite, _collectedSprite;

    public Sprite GrayScaleSprite { get => _grayScaleSprite; set => _grayScaleSprite = value; }
    public Sprite CollectedSprite { get => _collectedSprite; set => _collectedSprite = value; }

    private GameManager gm;
    public int keyId;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
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
                        gm.CollectItem(this);
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
                gm.CollectDuck(this);
                break;
        }
        
    }
}
