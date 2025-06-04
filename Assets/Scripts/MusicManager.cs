using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource audioSource;
    public AudioClip[] playlist;
    public Slider volumeSlider;

    private int currentTrackIndex = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Удаляем дубликат
            return;
        }

        if (playlist.Length > 0)
        {
            audioSource.clip = playlist[0];
            audioSource.Play();
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.1f);
            audioSource.volume = volumeSlider.value;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;
        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
}
