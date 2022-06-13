using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoThreePauseAccessibility : MonoBehaviour
{
    public GameObject codePanel;
    public GameObject canvas;
    public GameObject book;

    // Start is called before the first frame update
    void Start()
    {
        canvas = this.gameObject;
        codePanel = transform.GetChild(1).gameObject;
        book = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (codePanel.activeInHierarchy || book.activeInHierarchy)
        {
            UAP_AccessibilityManager.PauseAccessibility(true);
        }
        else
        {
            UAP_AccessibilityManager.PauseAccessibility(false);
        }
    }
}
