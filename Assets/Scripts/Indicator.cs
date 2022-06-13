using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieves the keycode object from the level
        key = GameObject.Find("dfk_crate_04_c");
    }

    // Update is called once per frame
    void Update()
    {
        //Sets scriptable object (the arrow) to point towards the key object
        transform.LookAt(key.transform.position);
    }
}
