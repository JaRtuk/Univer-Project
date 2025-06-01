using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRNoShake;
public class SwitchWeapon : MonoBehaviour
{
    
    public UseKalman NoShakePosition;
    public UseKalmanRotate NoShakeRotation;

    public GameObject[] WeaponList;
    public Material IsUse;
    int i = 0;


    // Update is called once per frame
    void Update()
    {
        //���ְ���ץ�ּ����ر��˲�
        //open/close 
            if (NoShakePosition.IsOpen)
            {
                NoShakePosition.IsOpen = false;
                NoShakeRotation.IsOpen = false;
                IsUse.SetColor("_Color",Color.white);
            }
            else
            {
                NoShakePosition.IsOpen = true;
                NoShakeRotation.IsOpen = true;
                IsUse.SetColor("_Color", Color.red);
            }
            



        //���ְ���ץ�ּ�����������
        //SwitchWeapon

            WeaponList[i].SetActive(false);
            i++;
            if (i >= WeaponList.Length)
            {
                i = 0;
            }
            WeaponList[i].SetActive(true);

            //����Ϊ��ǰ�������˲�����
            OnSwitch(WeaponList[i].GetComponent<NoShake>());
            

    }

    //�л�����
    //set this
    void OnSwitch(NoShake Weapon)
    {
        NoShakePosition.MaxV = Weapon.MaxPositionV;
        NoShakeRotation.MaxV = Weapon.MaxRotationV;
    }
}
