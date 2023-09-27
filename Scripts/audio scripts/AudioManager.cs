using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTracks; // Массив аудиотреков
    private int currentTrackIndex = 0; // Текущий индекс трека

    private void Start()
    {
        // Проверка наличия аудиотреков и начало проигрывания первого трека
        if (audioTracks.Length > 0)
        {
            PlayTrack(0);
        }
    }

    // Метод для проигрывания трека по индексу
    private void PlayTrack(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < audioTracks.Length)
        {
            // Остановка предыдущего трека, если он играет
            StopCurrentTrack();

            // Проигрывание выбранного трека
            audioTracks[trackIndex].Play();

            // Установка текущего индекса
            currentTrackIndex = trackIndex;
        }
    }

    // Метод для остановки текущего трека
    private void StopCurrentTrack()
    {
        if (currentTrackIndex >= 0 && currentTrackIndex < audioTracks.Length)
        {
            audioTracks[currentTrackIndex].Stop();
        }
    }

    // Метод для переключения на следующий трек
    public void PlayNextTrack()
    {
        // Остановка текущего трека
        StopCurrentTrack();

        // Переход к следующему треку
        currentTrackIndex++;

        // Если текущий индекс выходит за пределы массива, перейдите к первому треку
        if (currentTrackIndex >= audioTracks.Length)
        {
            currentTrackIndex = 0;
        }

        // Проигрывание следующего трека
        PlayTrack(currentTrackIndex);
    }
}