using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.InputSystem.XR;
using UnityEngine.Experimental.GlobalIllumination;

public class LightnerController : MonoBehaviour
{
    [SerializeField] public GrabParenter grabParenter;
    public Light pointLight;
    private UnityEngine.XR.InputDevice leftController;
    private bool powerOn = false;

    void Start()
{
    List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
    InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);

    if (devices.Count > 0)
    {
        leftController = devices[0]; // НЕ [1], а [0]
    }
    else
    {
        Debug.LogWarning("Левый контроллер не найден");
    }
}
    void Update()
    {
        if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryPressed) && primaryPressed && grabParenter != null && grabParenter.IsGrab())
        {
            Debug.Log("Button pressed");
            pointLight.enabled = false;
        }
    }
}
