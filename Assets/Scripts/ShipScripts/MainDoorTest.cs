using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorTest : MonoBehaviour
{
    PlayerStatsManager pSM;

    GameObject handlePivot;
    GameObject doorPivot;

    Camera mainCam;
    Vector2 mousePos;

    bool fullCycleComplete = false;
    public int progressCheck;
    float rotZ;

    float timer;
    public float doorAnimSpeed;

    public GameObject WinText;

    public AudioClip onCycleCompleteAudioClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // linking gameobjects to things in scene
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();

        handlePivot = GameObject.Find("HandlePivot");
        doorPivot = GameObject.Find("DoorPivot");

        audioSource = GetComponent<AudioSource>();

        WinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // checks if facing door, and if left mouse is held down
        if (pSM.playerDirection == "Backward" && Input.GetKey(KeyCode.Mouse0) && progressCheck > 0 && !pSM.isGameOver)
        {
            MousePosChecker();
        }
        // if wheel is spun enough, then open the door (rotate it -90 over 90/doorAnimSpeed frames)
        if (progressCheck <= 0 && timer / doorAnimSpeed >= -90)
        {
            //doorPivot.transform.rotation = Quaternion.Euler(timer / doorAnimSpeed, 0, 0);
            //timer--;
            WinText.SetActive(true);
        }
    }

    public void MousePosChecker()
    {
        mainCam = Camera.main;
        mousePos = Input.mousePosition;
        // creates the rotation vector from the center of the screen to the mouse cursor
        Vector2 rotation = mousePos - new Vector2(Screen.width / 2, Screen.height / 2);

        // converts the vector into an angle, then rotates the handle to that angle
        rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;     Debug.Log(rotZ);
        handlePivot.transform.rotation = Quaternion.Euler(0, 0, rotZ);


        // progress checker for rotating handle [[THIS CODE IS NOT FINAL -- I CAN LITERALLY ALREADY SEE A LOOPHOLE IN IMPLEMENTATION]]

        if (rotZ >= 0 && rotZ <= 90 && fullCycleComplete)
        {
            progressCheck--;
            fullCycleComplete = false;
            audioSource.clip = onCycleCompleteAudioClip;
            audioSource.Play();
        }

        if (rotZ >= -180 && rotZ <= -90)
        {
            fullCycleComplete = true;
        }

    }
}
