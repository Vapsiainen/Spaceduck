using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnergyMeter : MonoBehaviour
{
    [SerializeField]
    private Slider energyMeter;

    public void Init(int maxEnergy)
    {
        energyMeter.maxValue = maxEnergy;
        StartCoroutine(Demostrate());
    }

    public void ShowValue(int value)
    {
        if (value > energyMeter.maxValue)
            value = (int)energyMeter.maxValue;

        energyMeter.value = value;
    }

    private IEnumerator Demostrate()
    {
        while (energyMeter.value < energyMeter.maxValue)
        {
            yield return new WaitForSeconds(2);

            ShowValue((int)energyMeter.value + 10);
        }
    }
}
