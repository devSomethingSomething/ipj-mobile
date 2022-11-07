using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
