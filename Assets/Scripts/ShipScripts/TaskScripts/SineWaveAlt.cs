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
    }

    private void SineWaveDesync()
    {
        int random = UnityEngine.Random.Range(0, 120);
        if (random == 119)
        {
            amplitude += 0.0005f;
            frequency -= 0.001f;
            amplitude = Mathf.Clamp(amplitude, 0.5f, 2f);
            frequency = Mathf.Clamp(frequency, 1f, 2f);
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
