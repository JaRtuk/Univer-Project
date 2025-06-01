// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EmenyAmmo : MonoBehaviour
// {
//     [SerializeField] public Transform weapon;
//     [SerializeField] public EnemyStateManager manager;


//     public EmenyAmmo()
//     {
//         // weapon.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
//     }

//     public void SetPosition()
//     {
//         weapon.transform.rotation = Quaternion.Euler(-46.327f, -21.528f, -11.269f);
//         weapon.transform.position = new Vector3(-0.71f, -0.36f, 2.57f);
//     }
//     void Update()
//     {

//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EmenyAmmo : MonoBehaviour
{
    [SerializeField] private Transform weapon; // Присвойте в инспекторе

    private void Start()
    {
        if (weapon == null)
        {
            Debug.LogError("Weapon не присвоен в EmenyAmmo!");
            enabled = false; // Отключаем скрипт, если нет оружия
        }
    }

    public void SetPosition()
    {
        if (weapon == null) return; // Защита от NullReference

        weapon.transform.rotation = Quaternion.Euler(-46.327f, -21.528f, -11.269f);
        weapon.transform.position = new Vector3(-0.71f, -0.36f, 2.57f);
    }
}