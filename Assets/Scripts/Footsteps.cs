using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Footsteps : MonoBehaviour
{
    private CharacterController cc;
    public AudioSource audio;

    [SerializeField]
    [Range(0,10)]
    float volume;
    [SerializeField]
    [Range(0, 10)]
    float pitch;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 2f && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.8f, 1f);
            audio.pitch = Random.Range(0.8f, 1f);
            audio.Play();
        }
    }
}
