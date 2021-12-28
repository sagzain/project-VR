using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _despawnTime;

    void OnEnable()
    {
        StartCoroutine(DespawnBulletOnTime());
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
    }

    private IEnumerator DespawnBulletOnTime()
    {
        yield return new WaitForSeconds(_despawnTime);
        Destroy(gameObject);
    }
}
