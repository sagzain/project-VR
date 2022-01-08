using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Television : MonoBehaviour
{
    [Header("TV Settings")]
    [SerializeField] private List<VideoClip> _videos;
    // [Range(0,2)]
    // [SerializeField] private int _delayActivation;
    
    [Header("Screen Materials")]
    [SerializeField] private Material _ScreenOnMaterial;
    [SerializeField] private Material _ScreenOffMaterial;

    [Header("Light Materials")]
    [SerializeField] private Material _LightOnMaterial;
    [SerializeField] private Material _LightOffMaterial;

    private bool _isOn;
    private GameObject _screen;
    private GameObject _light;
    private AudioSource _audioSource;
    private VideoPlayer _videoPlayer;

    void Start()
    {
        _isOn = false;
        _screen = transform.Find("Screen").gameObject;
        _light = transform.Find("Light").gameObject;
        _audioSource = GetComponentInChildren<AudioSource>();
        _videoPlayer = GetComponentInChildren<VideoPlayer>();
    }

    public void ActivateTV()
    {
        if(_isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    void TurnOn()
    {
        _screen.GetComponent<MeshRenderer>().material = _ScreenOnMaterial;
        _light.GetComponent<MeshRenderer>().material = _LightOnMaterial;

        _videoPlayer.clip = _videos[Random.Range(0, _videos.Count)];
        _videoPlayer.Play();

        _isOn = true;
    }

    void TurnOff()
    {
        _screen.GetComponent<MeshRenderer>().material = _ScreenOffMaterial;
        _light.GetComponent<MeshRenderer>().material = _LightOffMaterial;

        _videoPlayer.Stop();

        _isOn = false;
    }
}
