using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibilityDebug : MonoBehaviour
{
    public UAP_AccessibilityManager accessibilityManager;
    // Start is called before the first frame update
    void Start()
    {
        accessibilityManager = GetComponent<UAP_AccessibilityManager>();
        accessibilityManager.m_DefaultState = true;
        accessibilityManager.m_SaveEnabledState = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
