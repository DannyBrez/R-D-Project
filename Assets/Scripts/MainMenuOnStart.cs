using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOnStart : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        canvas = this.transform.gameObject;

        //Disable all panels on startup
        for(int i=0; i<canvas.transform.childCount; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        //Enables Mainmenu and Screen Reader Popup on Startup
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
    }
}
