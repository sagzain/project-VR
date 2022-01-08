using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TrainBehaviour : MonoBehaviour
{
    [Header("Train Settings")]
    [Range(0f,1f)]
    [SerializeField] private float _speed;
    [SerializeField] private bool _isActive;

    private bool _isGrounded;
    private AudioSource _audioSource;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _isGrounded = Mathf.Abs(Vector3.Angle(transform.up, Vector3.up)) > 45 ? false : true;

        if(_isActive && _isGrounded)
        {
            MoveTrain();
        }
    }

    void MoveTrain()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void ActivateTrain()
    {
        if(_isActive)
        {
            _isActive = false;
            _audioSource.Stop();
        }
        else
        {
            _isActive = true;
            _audioSource.Play();
        }
    }

}
