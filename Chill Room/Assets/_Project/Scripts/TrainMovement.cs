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
            Debug.Log(other.gameObject);
        

            Quaternion q = other.transform.rotation;
            q.x = q.z = 0;
            // transform.rotation = Quaternion.Lerp(transform.rotation, q, 0.5f);
            StartCoroutine(RotateTrain(q));
        }
    }

    IEnumerator RotateTrain(Quaternion q)
    {
        yield return new WaitForSeconds(.25f);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 0.5f);
    }
}
