/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    [SerializeField] private Image oxygenBar;
    
    private float maxOxygen = 1f;
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
        if (Input.GetKeyDown(KeyCode.O))
        {
            currentOxygen -= 0.25f;
            UpdateOxygenBar();
        }
    }

    private void UpdateOxygenBar()
    {
        oxygenBar.fillAmount = currentOxygen / maxOxygen;
    }
}
*/