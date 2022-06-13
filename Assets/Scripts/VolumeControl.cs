using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]
    string _volumeParameter = "MasterVolume";
    [SerializeField]
    AudioMixer _masterMixer;
    [SerializeField]
    Slider _masterSlider;
    [SerializeField]
    float _multiplier = 30f;

    private void Awake()
    {
        _masterSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _masterSlider.value);
    }

    private void HandleSliderValueChanged(float value)
    {
        _masterMixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
    }
    // Start is called before the first frame update
    void Start()
    {
        _masterSlider.value = PlayerPrefs.GetFloat(_volumeParameter, _masterSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        if(_masterSlider.value == 0)
        {
            _masterMixer.SetFloat(_volumeParameter, -80);
        }
    }
}
