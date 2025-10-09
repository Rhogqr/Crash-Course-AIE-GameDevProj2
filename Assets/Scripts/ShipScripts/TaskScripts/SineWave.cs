using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class SineWave : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int points;

    public float amplitude = 1;
    public float frequency = 1;
    public float waveSpeed = 5;

    public Vector2 xLimits = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawSineWave();
    }

    void DrawSineWave()
    {
        float xStart = xLimits.x;
        float xFinish = xLimits.y;

        lineRenderer.positionCount = points;

        for (int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint/(points-1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin(((Mathf.PI * 2) * frequency * x) + Time.timeSinceLevelLoad * 5);
            lineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }
}
