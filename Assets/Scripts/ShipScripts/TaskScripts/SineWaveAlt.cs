using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class SineWaveAlt : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int pointsAlt;

    public float amplitude = 1;
    public float frequency = 1;
    public float waveSpeed = 5;

    public Slider ampSlider;
    public Slider freqSlider;

    public Vector2 xLimitsAlt = new Vector2(-2, 2);

    public bool commsFailure;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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

        else if (amplitude < 0.3 && frequency > 1.5f)
        {
            commsFailure = false;
        }

        if (frequency < 1.5f)
        {
            commsFailure = true;
        }
    }

    private void SineWaveDesync()
    {
        int random = UnityEngine.Random.Range(0, 15);
        if (random == 14)
        {
            amplitude += 0.001f;
            frequency -= 0.001f;
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
