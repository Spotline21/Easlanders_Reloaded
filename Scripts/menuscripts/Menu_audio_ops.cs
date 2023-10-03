using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu_audio_ops : MonoBehaviour
{

    public AudioMixer soundMixer; // ���������� ��� ����� ������ ����
    public Slider masterSlider; // ���������� ������� ��� ��������� �������
    public Slider musicSlider; // ���������� ������� ��� ��������� ������
    [SerializeField]
    private string masterVolumeParameter = "MasterVolume"; // ��� ��������� ��������� �������
    [SerializeField]
    private string musicVolumeParameter = "MusicVolume"; // ��� ��������� ��������� ������

    private void Start()
    {
        // ������������� �������� ��������� ��� �������
        if (soundMixer != null)
        {
            float masterVolume = PlayerPrefs.GetFloat(masterVolumeParameter, 0.75f); // �������� ������������ �������� ��������� �������
            float musicVolume = PlayerPrefs.GetFloat(musicVolumeParameter, 0.75f); // �������� ������������ �������� ��������� ������

            soundMixer.SetFloat(masterVolumeParameter, Mathf.Log10(masterVolume) * 20); // ��������� ��������� ������� � �������
            soundMixer.SetFloat(musicVolumeParameter, Mathf.Log10(musicVolume) * 20); // ��������� ��������� ������ � �������

            masterSlider.value = masterVolume; // ��������� �������� ��� �������
            musicSlider.value = musicVolume; // ��������� �������� ��� ������
        }
    }

    // ����� ��� ��������� ��������� �������
    public void SetMasterVolume(float volume)
    {
        if (soundMixer != null)
        {
            soundMixer.SetFloat(masterVolumeParameter, Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(masterVolumeParameter, volume); // ���������� �������� ��������� �������
        }
    }

    // ����� ��� ��������� ��������� ������
    public void SetMusicVolume(float volume)
    {
        if (soundMixer != null)
        {
            soundMixer.SetFloat(musicVolumeParameter, Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(musicVolumeParameter, volume); // ���������� �������� ��������� ������
        }
    }
}

