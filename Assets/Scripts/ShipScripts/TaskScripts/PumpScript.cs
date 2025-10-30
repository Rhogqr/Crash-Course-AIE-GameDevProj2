using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PumpScript : MonoBehaviour
{
    private Vector3 dragOffset;
    private float startY, minY, maxY, meterPrcnt;
    // private float maxY = 1.78;
    // private float minY = 1.247;
    public TextMeshProUGUI pumpMeter;
    private Vector3 currentPos;

    private void Start()
    {
        meterPrcnt = Mathf.Clamp(meterPrcnt, 0f, 100f);
        pumpMeter.text = meterPrcnt.ToString(meterPrcnt + "%");
    }

    void OnMouseDown()
    {
        startY = transform.position.y;
        dragOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
    }

    void OnMouseDrag()
    {
        minY = 1.247f;
        maxY = 1.78f;

        Vector3 currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        currentPos = Camera.main.ScreenToWorldPoint(currentScreenPos) + dragOffset;
        float yAxisLimit = Mathf.Clamp(currentPos.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, yAxisLimit, transform.position.z);

        if (transform.position.y == minY)
        {
            UpdateMeter();
        }
    }
    
   void UpdateMeter()
   {
        meterPrcnt += 10f;
        pumpMeter.text = meterPrcnt.ToString(meterPrcnt + "%");
    }
   
}

