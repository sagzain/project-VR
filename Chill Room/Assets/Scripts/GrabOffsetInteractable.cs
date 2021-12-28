using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntered(SelectEnterEventArgs enteredEventsArgs)
    {
        base.OnSelectEntered(enteredEventsArgs);
        UpdateCurrentInteractor(enteredEventsArgs.interactor);
    }

    protected override void OnSelectExited(SelectExitEventArgs exitedEventArgs)
    {
        base.OnSelectExited(exitedEventArgs);
    }

    private void UpdateCurrentInteractor(XRBaseInteractor interactor)
    {

    }
}
