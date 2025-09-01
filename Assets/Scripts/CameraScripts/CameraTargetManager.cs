using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetManager : MonoBehaviour
{
    GameObject Camera;
    CameraSwitchView CameraSwitchView;
    // Start is called before the first frame update
    void Start()
    {
        // Gets the camera and the variables associated with its script
        Camera = GameObject.Find("Main Camera");
        CameraSwitchView = Camera.GetComponent<CameraSwitchView>(); 

        // Rotates and moves that direction to wherever the camera needs to look at
        transform.Rotate(0, CameraSwitchView.degreesToTurn, 0);
        transform.position = transform.forward * 50;

        // Destroys after 0.1 seconds
        Destroy(this.gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
