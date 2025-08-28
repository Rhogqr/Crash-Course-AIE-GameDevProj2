using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineBar : MonoBehaviour
{
    [SerializeField] private Image engineBar;
    
    private float maxEngine = 100f;
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
        currentEngine -= 0.2f * Time.deltaTime;
        currentEngine = Mathf.Clamp(currentEngine, 0f, maxEngine);
        UpdateEngineBar();

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentEngine += 1f;
            UpdateEngineBar();
        }
    }

    private void UpdateEngineBar()
    {
        engineBar.fillAmount = currentEngine / maxEngine;
        currentEngine = Mathf.Clamp(currentEngine, 0f, maxEngine);
    }
}
