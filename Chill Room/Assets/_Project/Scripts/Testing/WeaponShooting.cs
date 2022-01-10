using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _outputPoint;
    
    public void ShootWeapon()
    {
        Instantiate(_bullet, _outputPoint.position, transform.rotation);
    }
}
