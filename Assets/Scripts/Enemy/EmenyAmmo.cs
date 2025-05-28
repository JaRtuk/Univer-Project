using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyAmmo : MonoBehaviour
{
    [SerializeField] public Transform weapon;
    [SerializeField] public EnemyStateManager manager;


    void Update()
    {
        // if (manager.currentState == manager.attakState)
        // {
        //     weapon.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        // }
    }
}
