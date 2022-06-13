using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleScript : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Text text;
    public string ToggleOff;
    public string ToggleOn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(toggle.isOn)
        {
            text.text = ToggleOn;
        }
        else
        {
            text.text = ToggleOff;
        }
    }
}
