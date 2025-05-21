using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class HandAnimation : MonoBehaviour
{
    [SerializeField]
    XRInputValueReader<float> m_TriggerInput;
    
    [SerializeField]
    XRInputValueReader<float> m_GridInput;
    
    [SerializeField] 
    Animator animator;

    private void Update()
    {
        animator.SetFloat("Trigger", m_TriggerInput.ReadValue());
        animator.SetFloat("Grid", m_GridInput.ReadValue());
    }
}