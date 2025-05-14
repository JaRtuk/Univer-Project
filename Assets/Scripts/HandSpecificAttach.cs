using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class HandSpecificAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Получаем объект взаимодействия (контроллер)
        var interactor = args.interactorObject as XRBaseControllerInteractor;

        if (interactor != null)
        {
            // Определяем тип руки через XRController
            var controller = interactor.GetComponent<XRController>();

            if (controller != null)
            {
                switch (controller.controllerNode)
                {
                    case UnityEngine.XR.XRNode.LeftHand:
                        attachTransform = leftAttachTransform;
                        break;
                    case UnityEngine.XR.XRNode.RightHand:
                        attachTransform = rightAttachTransform;
                        break;
                }
            }
        }

        base.OnSelectEntered(args);
    }
}
