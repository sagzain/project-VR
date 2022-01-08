using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    
    private bool _isPressed;

    private Vector3 _initialPosition;
    private ConfigurableJoint _configJoint;

    public UnityEvent onPressed, onReleased;

    void Awake()
    {
        _initialPosition = transform.localPosition;
        _configJoint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {

    }

    void ButtonPressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    void ButtonReleased()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Release");
    }
}
