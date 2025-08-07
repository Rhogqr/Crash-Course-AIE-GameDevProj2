using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraSwitchView : MonoBehaviour
{
    public bool mouseInZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // need to add animation / slow pan in code for the camera so that it doesnt just zip around, good enough for now
        if (Input.mousePosition.x < Screen.width * 1/10 && mouseInZone == false)
        {
            transform.Rotate(0, -90, 0);
            mouseInZone = true;
        }
        else if (Input.mousePosition.x > Screen.width * 9/ 10 && mouseInZone == false)
        {
            transform.Rotate(0, 90, 0);
            mouseInZone = true;
        }
        else if (Input.mousePosition.x > Screen.width * 1 / 10 && Input.mousePosition.x < Screen.width * 9 / 10)
        {
            mouseInZone = false;
        }
    }
}
