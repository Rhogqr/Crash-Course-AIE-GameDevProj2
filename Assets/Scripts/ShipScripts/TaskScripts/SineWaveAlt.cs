using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class SineWaveAlt : MonoBehaviour
{
    TaskDebuffAlien tDA;
    
    LineRenderer lineRenderer;
    public int pointsAlt;

    [SerializeField] float amplitude = 1;
    [SerializeField] float frequency = 1;
    [SerializeField] float waveSpeed = 5;

    public Slider ampSlider;
    public Slider freqSlider;

    [SerializeField] Vector2 xLimitsAlt = new Vector2(-2, 2);

    public bool commsFailure;

    float multiplier = 1;
    float tempMult;

    // Start is called before the first frame update
    void Start()
    {
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tDA.debuff1)
        {
            tempMult = multiplier * 3;
        }
        else
        {
            tempMult = multiplier;
        }

        DrawSineWaveAlt();
        SineWaveDesync();
        CommsFailChecker();
    }

    private void CommsFailChecker()
    {
        if (amplitude > 0.3f)
        {
            commsFailure = true;
        }

        else if (amplitude < 0.25 && frequency > 1.5f)
        {
            commsFailure = false;
        }

        if (frequency < 1.85f)
        {
            commsFailure = true;
        }
    }

    private void SineWaveDesync()
    {
        int random = UnityEngine.Random.Range(0, 15);
        if (random == 14)
        {
            amplitude += 0.001f * tempMult;
            frequency -= 0.001f * tempMult;
            amplitude = Mathf.Clamp(amplitude, 0.125f, 0.5f);
            frequency = Mathf.Clamp(frequency, 1f, 2f);
            ampSlider.value = amplitude;
            freqSlider.value = frequency;
        }
    }

    void DrawSineWaveAlt()
    {
        float xStart = xLimitsAlt.x;
        float xFinish = xLimitsAlt.y;

        lineRenderer.positionCount = pointsAlt;

        for (int currentPoint = 0; currentPoint < pointsAlt; currentPoint++)
        {
            float progress = (float)currentPoint / (pointsAlt - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin(((Mathf.PI * 2) * frequency * x) + Time.timeSinceLevelLoad * 5);
            lineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }

    public void AmplitudeSliderControl()
    {
        amplitude = ampSlider.value;
    }

    public void FrequencySliderControl()
    {
        frequency = freqSlider.value;
    }
}
