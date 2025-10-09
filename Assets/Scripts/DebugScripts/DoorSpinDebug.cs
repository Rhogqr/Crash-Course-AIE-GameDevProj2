using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSpinDebug : MonoBehaviour
{
    public MainDoorTest mDT;
    public DoorAlienAggro dAA;
    public TextMeshProUGUI spinsLeft;
    public TextMeshProUGUI spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        dAA = GameObject.Find("DoorMonsterManager").GetComponent<DoorAlienAggro>();
    }

    // Update is called once per frame
    void Update()
    {
        spinsLeft.text = "Door Progress: " + mDT.progressCheck;
        spinSpeed.text = "spins/second: " + (dAA.prevProgressCheck - mDT.progressCheck);
    }
}
