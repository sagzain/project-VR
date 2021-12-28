using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    [SerializeField] private XRBaseInteractor _interactor;

    private void OnEnable()
    {
        _interactor.selectEntered.AddListener(HideHand);
        _interactor.selectExited.AddListener(ShowHand);
    }

    private void HideHand(SelectEnterEventArgs args)
    {
        gameObject.SetActive(false);
    }

    private void ShowHand(SelectExitEventArgs args)
    {
        gameObject.SetActive(true);
    }
}
