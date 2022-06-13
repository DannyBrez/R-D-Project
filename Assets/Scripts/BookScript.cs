using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{

    public GameObject remember;
    private void Start()
    {
        transform.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerController.lockUser = true;
    }

    private void OnDisable()
    {
        PlayerController.lockUser = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.gameObject.SetActive(false);
            remember.SetActive(true);
        }
    }
}
