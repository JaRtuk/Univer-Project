using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightBlink : MonoBehaviour
{
    [Header("Настройки мигания")]
    [Tooltip("Сколько раз в секунду проходит полный цикл «погас-засветился»")]
    public float frequency = 2f;                // Гц

    [Tooltip("Минимальная яркость (0 = полностью тёмный)")]
    [Range(0f, 1f)]
    public float minIntensity = 0f;

    [Tooltip("Максимальная яркость (1 = изначальная яркость лампы)")]
    [Range(0f, 1f)]
    public float maxIntensity = 1f;

    private Light _light;
    private float _baseIntensity;

    private void Awake()
    {
        _light = GetComponent<Light>();          // Гарантированно есть
        _baseIntensity = _light.intensity;       // Запоминаем исходное значение
    }

    private void Update()
    {
        // t меняется от 0 до 1, создавая треугольную волну (Ping-Pong)
        float t = Mathf.PingPong(Time.time * frequency, 1f);

        // Линейно интерполируем интенсивность между min и max долями от исходного уровня
        _light.intensity = Mathf.Lerp(
            minIntensity * _baseIntensity,
            maxIntensity * _baseIntensity,
            t);
    }
}
