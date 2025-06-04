using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabParenter : MonoBehaviour
{
    private bool onGrab;
    public void OnGrab(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
        onGrab = true; 
    }

    public void OnUngrab(SelectExitEventArgs args)
    {
        args.interactableObject.transform.SetParent(null);
        onGrab = false;
    }

    public bool IsGrab()
    {
        return onGrab;
    }
}