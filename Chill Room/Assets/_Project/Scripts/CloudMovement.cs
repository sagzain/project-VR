using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] private int _speed;

    void Update()
    {
        transform.Rotate(transform.up, _speed * Time.deltaTime);
    }
}
