using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceFromPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject key, player;

    public Image slider;
    //Sets the furthest possible distance from the keycode, and the closest.
    private float highestDist = 25f;
    private float lowestDist = 0.05f;
    private float percentDist;

    public GameObject hotColdMeter;
    public GameObject remember;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the key object this script is attached too
        key = this.gameObject;
        //Gets the player object within the level
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        //Gets the distance between the keycode object and the player object
        float dist = Vector3.Distance(key.transform.position, 
                     player.transform.position);

        //Converts the distance into a decimal percentage (e.g: 0.40, 0.60, etc)
        percentDist = dist / highestDist - lowestDist;

        /*Sets the slider value of the hot and cold meter
        Higher the value, the closer the player is to the object */
        slider.fillAmount = percentDist;
        print("Distance from Keycode: " + dist);

        //Disables the hot and cold meter once the key is found
        if (remember.activeInHierarchy)
        {
            hotColdMeter.SetActive(false);
        }
    }


}
