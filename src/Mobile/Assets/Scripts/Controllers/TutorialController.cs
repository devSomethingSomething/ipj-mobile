using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private AudioClip controlsAudioClip;
    [SerializeField]
    private AudioClip escapeAudioClip;

    private void Start()
    {
        PlayTutorialAudio();
    }

    private void PlayTutorialAudio()
    {
        StartCoroutine(SoundManager.Instance.Say(new AudioClip[]
        {
            controlsAudioClip,
            escapeAudioClip
        }));
    }
}
