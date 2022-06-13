using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteLevel03 : MonoBehaviour
{

    public GameObject keyNoiseText;
    public GameObject listenToSound;
    // Start is called before the first frame update
    void Start()
    {
        keyNoiseText.SetActive(false);
        listenToSound.SetActive(false);
        activateKeyNoise();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activateKeyNoise()
    {
        if (keyNoiseText.activeInHierarchy == true)
        {
            return;
        }
        else
        {
            StartCoroutine(keyNoise());
        }
    }

    IEnumerator keyNoise()
    {
        yield return new WaitForSeconds(10);
        keyNoiseText.SetActive(true);
        yield return new WaitForSeconds(5);
        keyNoiseText.SetActive(false);
        if(listenToSound.activeInHierarchy)
        {
            
        }
        else
        {
            listenToSound.SetActive(true);
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
    }

}
