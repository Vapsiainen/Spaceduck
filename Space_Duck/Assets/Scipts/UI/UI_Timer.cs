using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Timer : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> hourglassSprites;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private Image hourglassImage;

    private int hourglassSpriteIndex = 0;
    private float spriteChangeInterval = 0.589f, spriteTimer = 0.0f;
    private float rotationMin = 170, rotationMax = 190;
    private float rotationSpeed = 10.0f;
    private float fullRotationSpeed = 15.0f;
    private bool fullRotate = false;    

    public void Init(float totalTime)
    {        
        UpdateTimeText(totalTime);
        StartCoroutine(RotateHourglass());
        StartCoroutine(CycleHourglassImage());
    }

    public void UpdateTime(float timeLeft)
    {
        if (timeLeft > 0)
            UpdateTimeText(timeLeft);
        else
        {
            StopAllCoroutines();
            UpdateTimeText(0);
        }
    }

    private void UpdateTimeText(float timeLeft)
    {
        timerText.text = timeLeft.ToString("F2");
    }

    private IEnumerator CycleHourglassImage()
    {
        while (true)
        {
            if (spriteTimer > spriteChangeInterval)
            {                
                hourglassSpriteIndex = hourglassSpriteIndex < hourglassSprites.Count - 1 ? hourglassSpriteIndex + 1 : 0;
                hourglassImage.sprite = hourglassSprites[hourglassSpriteIndex];
                spriteTimer = 0;
                fullRotate = hourglassSpriteIndex == hourglassSprites.Count - 1;
            }
            if(!fullRotate)
                spriteTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator RotateHourglass()
    {
        while (true)
        {
            while (hourglassImage.rectTransform.localEulerAngles.z > rotationMin || fullRotate)
            {
                hourglassImage.rectTransform.Rotate(Vector3.back, (fullRotate ? rotationSpeed * fullRotationSpeed : rotationSpeed) * Time.deltaTime);

                if (fullRotate && hourglassImage.rectTransform.localEulerAngles.z > rotationMin && hourglassImage.rectTransform.localEulerAngles.z > 355)
                    ResetHourglass();

                yield return new WaitForEndOfFrame();
            }
            while (hourglassImage.rectTransform.localEulerAngles.z < rotationMax || fullRotate)
            {
                hourglassImage.rectTransform.Rotate(Vector3.forward, (fullRotate ? rotationSpeed * fullRotationSpeed : rotationSpeed) * Time.deltaTime);

                if (fullRotate && hourglassImage.rectTransform.localEulerAngles.z < rotationMax && hourglassImage.rectTransform.localEulerAngles.z < 5)
                    ResetHourglass();

                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void ResetHourglass()
    {
        fullRotate = false;
        hourglassImage.rectTransform.Rotate(Vector3.back, 180);
        hourglassSpriteIndex = 0;
        hourglassImage.sprite = hourglassSprites[0];
    }
}
