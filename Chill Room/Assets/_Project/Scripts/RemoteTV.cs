using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteTV : MonoBehaviour
{
    public void PressPowerButton()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
            if(hit.collider.name == "TV")
            {
                hit.collider.gameObject.GetComponent<Television>().ActivateTV();
            }
        }   
    }
}
