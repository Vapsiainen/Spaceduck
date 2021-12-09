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

    public AudioSource quackSource;
    private float quackTimer = 8.0f, timer = 0;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (tag != "Duck")
            return;

        if (timer > quackTimer)
        {
            quackSource.Play();
            timer = 0;
            quackTimer = new System.Random().Next(8, 20);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (this.tag)
        {
            case "Key":
                if (true)
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
