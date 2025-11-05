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
    [SerializeField] AudioSource pumpAudioSource;
    Slider pumpSlider;


    private void Start()
    {
        // initialise oxygen to 100%
        meterPrcnt = 100;
        // display oxygen percentage on meter
        pumpMeter.text = meterPrcnt + "%";
        increaseOxygen = true;
        // start decreasing oxygen over time
        StartCoroutine(decreaseOxygenOverTime());
        // get slider component
        pumpSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        // if the oxygen meter is at or below 25%, enable blur effect
        if (meterPrcnt <= 25)
        {
             blurEffect.SetActive(true);
        }
        else
        {
            blurEffect.SetActive(false);
        }

        // when the slider is at the bottom, allow oxygen increase, but only once per full pump
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
        // increase oxygen by 10%, clamped to a maximum of 100%
        if (increaseOxygen)
        {
            meterPrcnt = Mathf.Clamp(meterPrcnt + 10, 0, 100);
            pumpMeter.text = meterPrcnt + "%";
            pumpAudioSource.Play();
            increaseOxygen = false;
        }
   }

    IEnumerator decreaseOxygenOverTime()
    {
        // decrease oxygen by 1% every 0.5 seconds
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            meterPrcnt = Mathf.Clamp(meterPrcnt-1, 0, 100);
            pumpMeter.text = meterPrcnt + "%";
        }
    }
}

