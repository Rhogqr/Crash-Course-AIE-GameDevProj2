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
        Camera = GameObject.Find("Main Camera");
        CameraSwitchView = Camera.GetComponent<CameraSwitchView>(); 
        transform.Rotate(0, CameraSwitchView.degreesToTurn, 0);
        transform.position = transform.forward * 50;
        Destroy(this.gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
