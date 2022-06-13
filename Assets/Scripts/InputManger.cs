using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using TMPro;

public class InputManger : MonoBehaviour
{
    [SerializeField]
    public static PlayerControls inputActions;

    private void Awake()
    {
        if (inputActions == null)
            inputActions = new PlayerControls();
    }

    public static void StartRebind(string actionName, int bindingIndex, TMP_Text statusText)
    {
        InputAction action = inputActions.asset.FindAction(actionName);
        if(action == null || action.bindings.Count <= bindingIndex)
        {
            Debug.Log("Couldn't find action or binding");
            return;
        }

        if (action.bindings[bindingIndex].isPartOfComposite)
        {
            var firstPartIndex = bindingIndex + 1;
            if(firstPartIndex < action.bindings.Count && action.bindings[firstPartIndex].isPartOfComposite)
            {
                DoRebind(action, bindingIndex, statusText, true);
            }
        }
        else
            DoRebind(action, bindingIndex, statusText, false);

    }

    private static void DoRebind(InputAction actionToRebind, int bindingIndex, TMP_Text statusText, bool allCompositeParts)
    {
        if (actionToRebind == null || bindingIndex < 0)
            return;

        statusText.text = $"Press a {actionToRebind.expectedControlType}";

        actionToRebind.Disable();

        var rebind = actionToRebind.PerformInteractiveRebinding(bindingIndex);

        rebind.OnComplete(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();

            if(allCompositeParts)
            {
                var nextBindingIndex = bindingIndex + 1;
                if(nextBindingIndex < actionToRebind.bindings.Count && actionToRebind.bindings[nextBindingIndex].isPartOfComposite)
                {
                    DoRebind(actionToRebind, nextBindingIndex, statusText, allCompositeParts);
                }
            }
        });

        rebind.OnCancel(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();
        });

        rebind.Start(); //Starts the Rebind Process
    }
}
