using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PumpScript : MonoBehaviour
{
    public int meterPrcnt;
    public TextMeshProUGUI pumpMeter;
    [SerializeField] GameObject blurEffect;
    bool increaseOxygen;

    Slider pumpSlider;


    private void Start()
    {
        meterPrcnt = 100;
        pumpMeter.text = meterPrcnt + "%";
        increaseOxygen = true;
        StartCoroutine(decreaseOxygenOverTime());

        pumpSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (meterPrcnt <= 25)
        {
             blurEffect.SetActive(true);
        }
        else
        {
            blurEffect.SetActive(false);
        }

        if (pumpSlider.value <= 0.1f)
        {
            increaseOxygen = true;
        }
        if (pumpSlider.value >= 0.9f)
        {
            UpdateMeter();
        }
    }
        
   void UpdateMeter()
   {
        if (increaseOxygen)
        {
            meterPrcnt = Mathf.Clamp(meterPrcnt + 10, 0, 100);
            pumpMeter.text = meterPrcnt + "%";
            increaseOxygen = false;
        }
   }

    IEnumerator decreaseOxygenOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            meterPrcnt = Mathf.Clamp(meterPrcnt-1, 0, 100);
            pumpMeter.text = meterPrcnt + "%";
        }
    }
}

