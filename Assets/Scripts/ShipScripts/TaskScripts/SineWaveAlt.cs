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

    [SerializeField] AudioSource commsBackSound;
    bool dontRepeatSound = true;
    // Start is called before the first frame update
    void Start()
    {
        // initialises scripts in other objects that this script needs a variable for
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        // initialises the linerenderer component
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the sinewave debuff is active, then speed up distortion by 3x, otherwise, set mult back to 1
        if (tDA.debuff1)
        {
            tempMult = multiplier * 3;
        }
        else
        {
            tempMult = multiplier;
        }

        // draw the sine wave every frame
        DrawSineWaveAlt();
        // slowly moves the sinewave out of sunc with the other one
        SineWaveDesync();
        // checks every frame if either amp. or freq. are too far from sync
        CommsFailChecker();
    }

    private void CommsFailChecker()
    {
        // if amp is higher than [value1], then set commsfailure true
        if (amplitude > 0.3f)
        {
            commsFailure = true;
            dontRepeatSound = false;
        }

        // if neither are too high or too low, then set commsfailure false
        else if (amplitude < 0.25 && frequency > 1.5f && !dontRepeatSound)
        {
            commsFailure = false;
            commsBackSound.Play();
            dontRepeatSound = true;
        }

        // if freq. is lower than [value2], then set comssfailure true
        if (frequency < 1.85f)
        {
            commsFailure = true;
            dontRepeatSound = false;
        }
    }

    private void SineWaveDesync()
    {
        // every frame 1/15 chance to slightly push the sinewaves out of sync (avg. 4x /second)
        int random = UnityEngine.Random.Range(0, 15);
        if (random == 0)
        {
            amplitude += 0.001f * tempMult;
            frequency -= 0.001f * tempMult;
            amplitude = Mathf.Clamp(amplitude, 0.125f, 0.5f);
            frequency = Mathf.Clamp(frequency, 1f, 2f);
            // sets the values of the sliders so that they move
            ampSlider.value = amplitude;
            freqSlider.value = frequency;
        }
    }

    void DrawSineWaveAlt()
    {
        // draws the sinewaves on the screen
        float xStart = xLimitsAlt.x;
        float xFinish = xLimitsAlt.y;

        lineRenderer.positionCount = pointsAlt;

        // makes the line renderer into a sinewave that is effected by the desynced variables
        for (int currentPoint = 0; currentPoint < pointsAlt; currentPoint++)
        {
            float progress = (float)currentPoint / (pointsAlt - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin(((Mathf.PI * 2) * frequency * x) + Time.timeSinceLevelLoad * 5);
            lineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }

    // when the player moves the either slider, set the slider value to that, so that the player input is handled
    public void AmplitudeSliderControl()
    {
        amplitude = ampSlider.value;
    }

    public void FrequencySliderControl()
    {
        frequency = freqSlider.value;
    }
}
