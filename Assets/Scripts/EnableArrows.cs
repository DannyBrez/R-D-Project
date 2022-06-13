using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableArrows : MonoBehaviour
{
    public GameObject arrow;
    public GameObject key;

    public void Start()
    {
        //Arrow is disabled on start
        arrow.SetActive(false);

        //Retrieves the keycode object from the level
        key = GameObject.Find("dfk_crate_04_c");
    }

    // Update is called once per frame
    void Update()
    {
        //Sets scriptable object (the arrow) to point towards the key object
        transform.GetChild(0).LookAt(key.transform.position);
    }

    //Activates the coroutine of EnableArrow()
    public void  activateArrow()
    {
        StartCoroutine(EnableArrow());
        print("Key Pressed: Arrow Enabled");
    }

    //Enables the arrow object for 2 seconds before disabling it. 
    IEnumerator EnableArrow()
    {
        arrow.SetActive(true);
        yield return new WaitForSeconds(2);
        arrow.SetActive(false);
    }
}
