using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabParenter : MonoBehaviour
{
    public void OnGrab(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }

    public void OnUngrab(SelectExitEventArgs args)
    {
        args.interactableObject.transform.SetParent(null);
    }
}


// using UnityEngine;

// public class KatanaGrab : MonoBehaviour
// {
//     [Header("Grab Settings")]
//     public float positionSmoothness = 20f;
//     public float rotationSmoothness = 15f;
    
//     private Rigidbody rb;
//     private Transform grabParent;
//     private bool isGrabbed;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         if (rb == null)
//         {
//             Debug.LogError("Rigidbody component is missing!");
//             gameObject.SetActive(false);
//         }
//     }

//     // Вызывайте эту функцию при захвате объекта
//     public void Grab(Transform controller)
//     {
//         isGrabbed = true;
//         grabParent = controller;
        
//         // Настройки для плавного движения
//         rb.interpolation = RigidbodyInterpolation.Interpolate;
//         rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
//         rb.isKinematic = false;
//     }

//     // Вызывайте эту функцию при отпускании объекта
//     public void Ungrab()
//     {
//         isGrabbed = false;
//         grabParent = null;
//     }

//     void FixedUpdate()
//     {
//         if (!isGrabbed || grabParent == null) return;
        
//         // Плавное перемещение
//         Vector3 targetPosition = grabParent.position;
//         Vector3 newPosition = Vector3.Lerp(rb.position, targetPosition, positionSmoothness * Time.fixedDeltaTime);
//         rb.MovePosition(newPosition);
        
//         // Плавное вращение
//         Quaternion targetRotation = grabParent.rotation;
//         Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSmoothness * Time.fixedDeltaTime);
//         rb.MoveRotation(newRotation);
        
//         // Сбрасываем скорости для предотвращения "дергания"
//         rb.velocity = Vector3.zero;
//         rb.angularVelocity = Vector3.zero;
//     }
// }


