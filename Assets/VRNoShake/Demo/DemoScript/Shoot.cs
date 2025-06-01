using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shoot : MonoBehaviour
{

    // Start is called before the first frame update
    public Transform FirePoint;//��ǹ��
    public GameObject Bullet;//�ӵ�
    public float V = 30f;//�ӵ��ٶ�
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {

            GameObject newbullet =  Instantiate(Bullet);
            newbullet.transform.position = FirePoint.position;
            newbullet.transform.rotation = FirePoint.rotation;
            newbullet.GetComponent<Rigidbody>().velocity = newbullet.transform.forward * V;
        }
    }
}
