using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public void OnDamageDetected(int damage)
    {
        Debug.Log($"Игрок получил" + damage + "урона");
    }
}
