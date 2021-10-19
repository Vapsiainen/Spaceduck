using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emulations : MonoBehaviour
{
    public GameObject collectablePrefab;
    public Sprite collectedSecondSprite, grayedSecondSprite;

    private bool gameOver = false;
    private float currTime = 30.0f;
    void Start()
    {
        List<ICollectable> collectables = new List<ICollectable>();
        collectables.Add(Instantiate(collectablePrefab).GetComponent<Collectable>());

        Collectable collectable = Instantiate(collectablePrefab).GetComponent<Collectable>();
        collectable.CollectedSprite = collectedSecondSprite;
        collectable.GrayScaleSprite = grayedSecondSprite;
        collectable.debugSeed = 2;
        collectables.Add(collectable);

        FindObjectOfType<UIManager>().InitializeUI(collectables, currTime);
    }

    void Update()
    {
        currTime -= Time.deltaTime;
        FindObjectOfType<UI_Timer>().UpdateTime(currTime);

        if(currTime <= 0 && !gameOver)
        {
            gameOver = true;
            FindObjectOfType<UIManager>().ShowGameOver();
        }
    }
}
