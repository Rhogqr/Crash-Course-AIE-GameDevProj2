using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// as of now, most of this script does nothing. its currently linked to the door so dont delete this please!
// i (reuben) plan to use this as storage for variables that revolve around the player (current rotation, time left, player health, etc.)

public class PlayerStatsManager : MonoBehaviour
{
    public GameObject mainPlayerCam;
    public string playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayerCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        // because of the way that the camera animation works, the timing on this update is inconsistent. fix later?
        float currentDirection = mainPlayerCam.transform.rotation.eulerAngles.y;
        if (currentDirection == 0)
        {
            // Forward
            playerDirection = "Forward";
        }
        else if (currentDirection == 270)
        {
            // Left
            playerDirection = "Left";
        }
        else if (currentDirection == 90)
        {
            // Right
            playerDirection = "Right";
        }
        else if (currentDirection == 180)
        {
            // Backward
            playerDirection = "Backward";
        }
        else
        {
            // how
        }
    }
}
