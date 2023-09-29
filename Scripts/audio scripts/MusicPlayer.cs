using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;
    private int _currentClipIndex = 0;
    private bool _isPaused = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnActiveSceneChanged(Scene arg0, Scene arg1)
    {
        // ќстанавливаем воспроизведение аудио при смене сцены
        _audioSource.Stop();
    }

    private void Start()
    {
        // Ќачинаем воспроизведение аудио при старте игры
        PlayCurrentAudioClip();
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    private void Update()
    {
        // ѕровер€ем, если текущий трек завершилс€, и начинаем следующий
        if (!_audioSource.isPlaying && !_isPaused)
        {
            PlayNextAudioClip();
        }
    }

    private void PlayCurrentAudioClip()
    {
        // ¬оспроизводим текущий аудиоклип
        if (_audioClips.Length > 0)
        {
            _audioSource.clip = _audioClips[_currentClipIndex];
            _audioSource.Play();
        }
    }

    private void PlayNextAudioClip()
    {
        // ”величиваем индекс аудиоклипа и воспроизводим следующий
        _currentClipIndex = (_currentClipIndex + 1) % _audioClips.Length;
        PlayCurrentAudioClip();
    }

    private void OnApplicationPause(bool isPaused)
    {
        _isPaused = isPaused;
        if (isPaused)
        {
            // »гра была свернута
            _audioSource.Pause();
        }
        else
        {
            // »гра развернулась
            if (!_audioSource.isPlaying)
            {
                PlayCurrentAudioClip();
            }
        }
    }
}