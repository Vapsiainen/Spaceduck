using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField]
    private Sprite _grayScaleSprite, _collectedSprite;   

    public Sprite GrayScaleSprite { get => _grayScaleSprite; set => _grayScaleSprite = value; }
    public Sprite CollectedSprite { get => _collectedSprite; set => _collectedSprite = value; }
    public int debugSeed = 1;

    void Start()
    {
        StartCoroutine(DEBUG_SimulateTheItemCollectionAfterRandomTime());
    }

    private IEnumerator DEBUG_SimulateTheItemCollectionAfterRandomTime()
    {
        yield return new WaitForSeconds(new System.Random(debugSeed).Next(1, 30));

        FindObjectOfType<UI_Collectables>().CollectItem(this);
    }
}
