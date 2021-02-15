using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    public  AudioSource[] _mAudioSource;

    private void Awake()
    {
        _mAudioSource = GetComponents<AudioSource>();

    }

    public void flow_play()
    {
        _mAudioSource[0].Play();
    }

    public void compose_play()
    {
        _mAudioSource[1].Play();
    }

    public void beats_play()
    {
        _mAudioSource[2].Play();
    }
}