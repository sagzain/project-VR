using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    [Range(0f, .5f)]
    [SerializeField] private float _speed;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Waypoint"))
        {
            float angle = Quaternion.Angle(other.transform.rotation, transform.rotation);
            Debug.Log(angle);
            StartCoroutine(SmoothRotation(angle));
        }
    }

    IEnumerator SmoothRotation(float angle)
    {

        for(int i = 0; i <= angle; i++)
        {
            transform.Rotate(transform.up, 1);
            yield return new WaitForSeconds(.01f);
        }
        
    }
}
