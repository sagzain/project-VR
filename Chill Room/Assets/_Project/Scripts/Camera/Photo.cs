using System.Collections;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(XROffsetInteractable))]
public class Photo : MonoBehaviour
{
    [Header("Photo Settings")]
    [Range(0.2f, 0.5f)]
    [Tooltip("Amount of distance the photo is going to be moved by the animation.")]
    [SerializeField] private float _zShifting;

    private int _delayTime;
    public void SetDelayTime(int value) { _delayTime = value; }

    private Vector3 _initialScale;
    private Rigidbody _rigidbody;
    private XROffsetInteractable _interactableScript;

    void Awake()
    {
        // Initial localScale to restore at the end of the animation.
        _initialScale = transform.localScale;

        // Get the components from the game objects
        _rigidbody = GetComponent<Rigidbody>();
        _interactableScript = GetComponent<XROffsetInteractable>();

        // Disable physics from the rigidbody to avoid photo falling to the ground.
        _rigidbody.isKinematic = true;

        // Sets the Z from the localScale to make the animation of the photo going out. 
        Vector3 vector = transform.localScale;
        vector.z = 0;
        transform.localScale = vector;

        // Disable the interactable script so we can't interact with the photo until is out.
        _interactableScript.enabled = false;
    }

    void Start()
    {
        // Starts the animation coroutine
        StartCoroutine(AnimationRoutine());
    }

    /*
        Animate the photo using DOTween.
        Scale to the localScale stored when OnEnabled is called.
    */
    IEnumerator AnimationRoutine()
    {
        // In the sequence we can add any DOTween code and wait until is completed.
        Sequence tweenSequence = DOTween.Sequence();
        tweenSequence.Append(transform.DOLocalMoveZ(_zShifting, _delayTime));
        tweenSequence.Join(transform.DOScale(_initialScale, _delayTime));

        yield return tweenSequence.Play().WaitForCompletion();
 
        // Enable physics, clear parent and enable interactions.
        transform.SetParent(null);
        _rigidbody.isKinematic = false;
        _interactableScript.enabled = true;
    }
}
