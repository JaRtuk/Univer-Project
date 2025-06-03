using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] GameObject Sphere;
    private Rigidbody rb;
    private Collider Col;
    private GrabParenter grabParenter;
    private XRGrabInteractable xRGrabInteractable;
    private bool InAria;
    private bool HaveObject = false;
    private bool pauseScript = false;

    private void OnTriggerEnter(Collider other)
    {
        if (HaveObject) return;
        
        if (other.CompareTag("Grabbable") || other.CompareTag("Weapon"))
        {
            InAria = true;
            HaveObject = true;
            Col = other;
            grabParenter = other.GetComponent<GrabParenter>();
            xRGrabInteractable = other.GetComponent<XRGrabInteractable>();
            rb = other.attachedRigidbody;

            other.transform.SetParent(Sphere.transform, true);
            other.transform.localPosition = new Vector3(0f, 0f, 0f);

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            pauseScript = true;
            Invoke("UnFreeze", 1f);
        }
    }

    private void UnFreeze()
    {
        pauseScript = false;
    }

    private void Update()
    {
        if (pauseScript) return;

        if (xRGrabInteractable != null && xRGrabInteractable.useDynamicAttach)
        {
            if (!InAria && HaveObject)
            {
                //rb.useGravity = true;
                rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints.None;
                Col.transform.SetParent(null);
                HaveObject = false;
            }

            if (grabParenter != null)
            {
                if (grabParenter.IsGrab() && HaveObject)
                {
                    //rb.useGravity = true;
                    rb.isKinematic = false;
                    rb.constraints = RigidbodyConstraints.None;
                    Col.transform.SetParent(null);
                    HaveObject = false;
                }
            }
        }
        else
        {
            if (!InAria && HaveObject)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints.None;
                Col.transform.SetParent(null);
                HaveObject = false;
            }

            if (grabParenter != null)
            {
                if (grabParenter.IsGrab() && HaveObject)
                {
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    rb.constraints = RigidbodyConstraints.None;
                    Col.transform.SetParent(null);
                    HaveObject = false;
                }
            }
        }
        if (HaveObject)
        {
            Col.transform.position = Sphere.transform.position;
        }

        if (rb != null && !HaveObject)
        {
            rb.useGravity = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        InAria = false;
    }
}
