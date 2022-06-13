using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeToComplete : MonoBehaviour
{
    private int timeInSecond = 0;
    private float levelTimer = 0.0f;
    private bool updateTimer = false;
    private string timerTex = "";

    public TMP_Text timerText;

    void Start()
    {
        updateTimer = true;
        levelTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(updateTimer)
        {
            levelTimer += Time.deltaTime * 1;

            timerTex = levelTimer.ToString("f2");

            timerText.text = (timerTex + "Seconds");
        }
    }
}
