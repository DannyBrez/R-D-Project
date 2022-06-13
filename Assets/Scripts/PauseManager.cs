using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pause;
    public PlayerInput playerInput;

    public void Start()
    {

    }

    public void PauseGame()
    {
        pause.transform.GetChild(0).gameObject.SetActive(true);
        PlayerController.lockUser = true;
        playerInput.SwitchCurrentActionMap("Menu");
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pause.transform.GetChild(0).gameObject.SetActive(false);
        PlayerController.lockUser = false;
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        PlayerController.lockUser = true;
        Time.timeScale = 1;
    }
    public void LevelComplete()
    {
        PlayerController.lockUser = true;
        playerInput.SwitchCurrentActionMap("Menu");
        Time.timeScale = 0;
    }
}
