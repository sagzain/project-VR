using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    [SerializeField] private List<XRBaseInteractor> _interactors; 

    private void OnEnable()
    {
        foreach(XRBaseInteractor interactor in _interactors)
        {
            interactor.selectEntered.AddListener(HideHand);
            interactor.selectExited.AddListener(ShowHand);
        }

    }

    private void HideHand(SelectEnterEventArgs args)
    {
        if(args.interactableObject.GetType() == typeof(XRGrabAndHideInteractable))
        {
            args.interactorObject.transform.GetChild(0).transform.Find("Mesh").gameObject.SetActive(false);
        }
    }

    private void ShowHand(SelectExitEventArgs args)
    {
        if(args.interactableObject.GetType() == typeof(XRGrabAndHideInteractable))
        {
            args.interactorObject.transform.GetChild(0).transform.Find("Mesh").gameObject.SetActive(true);
        }
    }
}
