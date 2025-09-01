/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineBar : MonoBehaviour
{
    [SerializeField] private Image engineBar;
    
    private float maxEngine = 1f;
    private float currentEngine;
    
    // Start is called before the first frame update
    void Start()
    {
        currentEngine = maxEngine;
        UpdateEngineBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentEngine -= 0.25f;
            UpdateEngineBar();
        }
    }

    private void UpdateEngineBar()
    {
        engineBar.fillAmount = currentEngine / maxEngine;
    }
}
*/