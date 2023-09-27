using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTracks; // ������ �����������
    private int currentTrackIndex = 0; // ������� ������ �����

    private void Start()
    {
        // �������� ������� ����������� � ������ ������������ ������� �����
        if (audioTracks.Length > 0)
        {
            PlayTrack(0);
        }
    }

    // ����� ��� ������������ ����� �� �������
    private void PlayTrack(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < audioTracks.Length)
        {
            // ��������� ����������� �����, ���� �� ������
            StopCurrentTrack();

            // ������������ ���������� �����
            audioTracks[trackIndex].Play();

            // ��������� �������� �������
            currentTrackIndex = trackIndex;
        }
    }

    // ����� ��� ��������� �������� �����
    private void StopCurrentTrack()
    {
        if (currentTrackIndex >= 0 && currentTrackIndex < audioTracks.Length)
        {
            audioTracks[currentTrackIndex].Stop();
        }
    }

    // ����� ��� ������������ �� ��������� ����
    public void PlayNextTrack()
    {
        // ��������� �������� �����
        StopCurrentTrack();

        // ������� � ���������� �����
        currentTrackIndex++;

        // ���� ������� ������ ������� �� ������� �������, ��������� � ������� �����
        if (currentTrackIndex >= audioTracks.Length)
        {
            currentTrackIndex = 0;
        }

        // ������������ ���������� �����
        PlayTrack(currentTrackIndex);
    }
}