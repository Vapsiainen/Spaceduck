using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Collectables : MonoBehaviour
{
    [SerializeField]
    private GameObject collectableImagePrefab;
    [SerializeField]
    private Transform collectableImageParent;

    private List<Image> collectableImages = new List<Image>();
    private float imgScaleMin = 1.0f, imgScaleMax = 1.4f;
    private int animationCount = 3;

    public void Init(List<Item> items)
    {
        foreach (Item item in items)
        {
            Image imagePrefab = Instantiate(collectableImagePrefab, collectableImageParent).GetComponent<Image>();
            imagePrefab.sprite = item.GrayScaleSprite;
            
            collectableImages.Add(imagePrefab);
        }
    }

    public void CollectItem(Item collectedItem)
    {
        //TODO: This might need some sound effect to play when collected?
        Image img = collectableImages.First(x => x.sprite == collectedItem.GrayScaleSprite);
        img.sprite = collectedItem.CollectedSprite;
        StartCoroutine(AnimateCollectableIcon(img));
    }

    private IEnumerator AnimateCollectableIcon(Image image)
    {
        for (int i = 0; i < animationCount; i++)
        {
            while (image.rectTransform.localScale.x < imgScaleMax)
            {
                image.rectTransform.localScale = new Vector3(image.rectTransform.localScale.x + Time.deltaTime, image.rectTransform.localScale.y + Time.deltaTime, 0);
                yield return new WaitForEndOfFrame();
            }
            image.rectTransform.localScale = new Vector3(imgScaleMax, imgScaleMax, 0);
            while (image.rectTransform.localScale.x > imgScaleMin)
            {
                image.rectTransform.localScale = new Vector3(image.rectTransform.localScale.x - Time.deltaTime, image.rectTransform.localScale.y - Time.deltaTime, 0);
                yield return new WaitForEndOfFrame();
            }
            image.rectTransform.localScale = new Vector3(imgScaleMin, imgScaleMin, 0);
        }
    }
}
