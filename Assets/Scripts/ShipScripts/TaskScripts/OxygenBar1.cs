using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    [SerializeField] private Image oxygenBar;
    
    private float maxOxygen = 100f;
    private float currentOxygen;
    
    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = maxOxygen;
        UpdateOxygenBar();
    }

    // Update is called once per frame
    void Update()
    {
        currentOxygen -= 0.5f * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0f, maxOxygen);
        UpdateOxygenBar();

        if (Input.GetKeyDown(KeyCode.O))
        {
            currentOxygen += 1f;
            UpdateOxygenBar();
        }
    }

    private void UpdateOxygenBar()
    {
        oxygenBar.fillAmount = currentOxygen / maxOxygen;
        currentOxygen = Mathf.Clamp(currentOxygen, 0f, maxOxygen);
    }
}
