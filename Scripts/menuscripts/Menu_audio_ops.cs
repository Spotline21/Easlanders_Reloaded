using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu_audio_ops : MonoBehaviour
{

    public AudioMixer soundMixer; // Перетащите ваш аудио миксер сюда
    public Slider masterSlider; // Перетащите слайдер для громкости мастера
    public Slider musicSlider; // Перетащите слайдер для громкости музыки
    [SerializeField]
    private string masterVolumeParameter = "MasterVolume"; // Имя параметра громкости мастера
    [SerializeField]
    private string musicVolumeParameter = "MusicVolume"; // Имя параметра громкости музыки

    private void Start()
    {
        // Инициализация значений слайдеров при запуске
        if (soundMixer != null)
        {
            float masterVolume = PlayerPrefs.GetFloat(masterVolumeParameter, 0.75f); // Загрузка сохраненного значения громкости мастера
            float musicVolume = PlayerPrefs.GetFloat(musicVolumeParameter, 0.75f); // Загрузка сохраненного значения громкости музыки

            soundMixer.SetFloat(masterVolumeParameter, Mathf.Log10(masterVolume) * 20); // Установка громкости мастера в миксере
            soundMixer.SetFloat(musicVolumeParameter, Mathf.Log10(musicVolume) * 20); // Установка громкости музыки в миксере

            masterSlider.value = masterVolume; // Установка слайдера для мастера
            musicSlider.value = musicVolume; // Установка слайдера для музыки
        }
    }

    // Метод для изменения громкости мастера
    public void SetMasterVolume(float volume)
    {
        if (soundMixer != null)
        {
            soundMixer.SetFloat(masterVolumeParameter, Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(masterVolumeParameter, volume); // Сохранение значения громкости мастера
        }
    }

    // Метод для изменения громкости музыки
    public void SetMusicVolume(float volume)
    {
        if (soundMixer != null)
        {
            soundMixer.SetFloat(musicVolumeParameter, Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(musicVolumeParameter, volume); // Сохранение значения громкости музыки
        }
    }
}

