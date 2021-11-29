using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Level : MonoBehaviour
{
    public TextMeshProUGUI bestTime;
    public Image ducklingImage;
    public Sprite notCollectedDucklingSprite, collectedDucklingSprite;
    public Image shader;

    public void Show(bool cleared, float time, bool collected)
    {
        shader.gameObject.SetActive(!cleared);
        bestTime.text = "Record: " + (!cleared || time == 0 ? "??.??" : time.ToString("0.00"));
        ducklingImage.sprite = cleared && collected ? collectedDucklingSprite : notCollectedDucklingSprite;
    }
}
