using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class CameraSwitchView : MonoBehaviour
{
    public bool mouseInZone = false;
    Quaternion lookRotation;
    public float degreesToTurn;
    public GameObject cameraTarget;
    GameObject cameraTargetDummy;
    public bool delayCheck = false;
    private Coroutine LookCoroutine;
    public float turnSpeed = 0.33f;
    int currentRotation = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // need to add animation / slow pan in code for the camera so that it doesnt just zip around, good enough for now
        if (Input.mousePosition.x < Screen.width * 1 / 10 && mouseInZone == false && currentRotation != 0)
        {

            Instantiate(cameraTarget);
            Debug.Log("Spawned CameraTarget");
            mouseInZone = true;
            degreesToTurn = Mathf.Clamp(-90 + degreesToTurn, -90, 90);

            if (LookCoroutine != null)
            {
                StopCoroutine(LookCoroutine);
                Debug.Log("test 1");
            }
            LookCoroutine = StartCoroutine(LookAt());
        }
        else if (Input.mousePosition.x > Screen.width * 9 / 10 && mouseInZone == false && currentRotation != 0)
        {
            Instantiate(cameraTarget);
            Debug.Log("Spawned CameraTarget");
            mouseInZone = true;
            degreesToTurn = Mathf.Clamp(90 + degreesToTurn, -90, 90);

            if (LookCoroutine != null)
            {
                StopCoroutine(LookCoroutine);
                Debug.Log("test 2");
            }
            LookCoroutine = StartCoroutine(LookAt());
        }
        else if (Input.mousePosition.x > Screen.width * 1 / 10 && Input.mousePosition.x < Screen.width * 9 / 10 && Input.mousePosition.y < Screen.width * 1 / 10 && mouseInZone == false)
        {
                Instantiate(cameraTarget);
                Debug.Log("Spawned CameraTarget");
                mouseInZone = true;
                degreesToTurn = 180 * currentRotation;

                if (LookCoroutine != null)
                {
                    StopCoroutine(LookCoroutine);
                    Debug.Log("test 2");
                }
                LookCoroutine = StartCoroutine(LookAt());
                if (currentRotation != 0)
                {
                    currentRotation = 0;
                }
                else
                {
                    currentRotation = 1;
                }
        }

        else if (Input.mousePosition.x > Screen.width * 1 / 10 && Input.mousePosition.x < Screen.width * 9 / 10 && Input.mousePosition.y > Screen.width * 1/10)
        {
            mouseInZone = false;
        }
    }

    private IEnumerator LookAt()
    {
        yield return new WaitForEndOfFrame();
        cameraTargetDummy = GameObject.FindGameObjectWithTag("Target");
            lookRotation = Quaternion.LookRotation(cameraTargetDummy.transform.position - transform.position);
        

            Debug.Log("LookRotation = " + lookRotation);
            float time = 0;
            while (time < 1)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
                time += Time.deltaTime * turnSpeed;
                yield return null;
            }
    }

}
