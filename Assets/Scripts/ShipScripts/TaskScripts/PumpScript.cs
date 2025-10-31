using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PumpScript : MonoBehaviour
{
    private Vector3 dragOffset;
    private float startY, minY, maxY;
    public int meterPrcnt;
    public TextMeshProUGUI pumpMeter;
    private Vector3 currentPos;
    bool increaseOxygen;
    private void Start()
    {
        meterPrcnt = 100;
        pumpMeter.text = meterPrcnt.ToString(meterPrcnt + "%");
        increaseOxygen = true;
        StartCoroutine(decreaseOxygenOverTime());
    }

    private void Update()
    {
        /*
         * if (meterPrcnt <= 50)
         * {
         *      blur the screen
         * }
         * 
         * if (gameOver)
         * {
         *      StopAllCoroutines();
         * }
         */
    }

    void OnMouseDown()
    {
        startY = transform.position.y;
        dragOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
    }

    void OnMouseDrag()
    {
        minY = -0.21f;
        maxY = 0.314f;

        Vector3 currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        currentPos = Camera.main.ScreenToWorldPoint(currentScreenPos) + dragOffset;
        float yAxisLimit = Mathf.Clamp(currentPos.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, yAxisLimit, transform.position.z);

        if (transform.position.y == minY)
        {
            UpdateMeter();
        }
        if (transform.position.y == maxY)
        {
            increaseOxygen = true;
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

