using UnityEngine;

public class CardInArea : MonoBehaviour
{
    public GameObject left_door;
    public GameObject right_door;
    public GameObject card;

    private bool m_is_open = false;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == card && !m_is_open)
        {
            left_door.transform.position += new Vector3(0, -1.3f,0);
            right_door.transform.position += new Vector3(0, 1.3f,0);
            
            m_is_open = true;
        }
    }
}
