using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;
    private int _currentClipIndex = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnActiveSceneChanged(Scene arg0, Scene arg1)
    {
        // ������������� ��������������� ����� ��� ����� �����
        _audioSource.Stop();
    }

    private void Start()
    {
        // �������� ��������������� ����� ��� ������ ����
        PlayCurrentAudioClip();
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    private void Update()
    {
        // ���������, ���� ������� ���� ����������, � �������� ���������
        if (!_audioSource.isPlaying)
        {
            PlayNextAudioClip();
        }
    }

    private void PlayCurrentAudioClip()
    {
        // ������������� ������� ���������
        if (_audioClips.Length > 0)
        {
            _audioSource.clip = _audioClips[_currentClipIndex];
            _audioSource.Play();
        }
    }

    private void PlayNextAudioClip()
    {
        // ����������� ������ ���������� � ������������� ���������
        _currentClipIndex = (_currentClipIndex + 1) % _audioClips.Length;
        PlayCurrentAudioClip();
    }
}