using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeFrame : MonoBehaviour
{

    [SerializeField]
    private TMP_Text codeText;

    [SerializeField]
    private string levelPassword;

    private string codeTextValue = "";

    //Level Complete
    public PauseManager pm;
    public GameObject levelComplete;


    private void Start()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerController.lockUser = true;
        codeTextValue = "";
        codeText.color = Color.white;
    }

    private void OnDisable()
    {
        PlayerController.lockUser = false;
    }

    private void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == levelPassword)
        {
            StartCoroutine(CorrectPassword());
        }

        if (codeTextValue.Length == 4 && codeTextValue != levelPassword)
        {
            StartCoroutine(WrongPassword());
        
        }
        //Escapes from
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
    IEnumerator CorrectPassword()
    {
        print("LEVEL COMPLETE");
        codeText.color = Color.green;
        yield return new WaitForSeconds(2);
        //Level Complete Code
        transform.parent.gameObject.SetActive(false);
        levelComplete.SetActive(true);
        pm.LevelComplete();

    }
    IEnumerator WrongPassword()
    {
        codeTextValue = "ERROR";
        codeText.color = Color.red;
        yield return new WaitForSeconds(4);
        codeTextValue = "";
        codeText.color = Color.white;
    }
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
