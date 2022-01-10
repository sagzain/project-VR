using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberActivation : MonoBehaviour
{
    [SerializeField] private GameObject _saberObject;
    [SerializeField] private bool _active;

    public void ActivateLightsaber()
    {
        if (_active)
        {
            SwitchLightsaberOff();
        }
        else
        {
            SwitchLightsaberOn();
        }
    }

    private void SwitchLightsaberOn()
    {
        _saberObject.SetActive(true);
        _active = true;
    }

    private void SwitchLightsaberOff()
    {
        _saberObject.SetActive(false);
        _active = false;
    }
}
