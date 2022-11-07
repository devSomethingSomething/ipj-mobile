using System.Collections;
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

    private void Start()
    {
        // How to call say method:
        /* StartCoroutine(Say(new AudioClip[] { 
            WordManager.Instance.Hello, WordManager.Instance.World
        })); */
    }

    // Can still be used for longer sentences if needed
    public void Play(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public IEnumerator Say(AudioClip[] audioClips)
    {
        foreach (AudioClip audioClip in audioClips)
        {
            Play(audioClip);

            while (audioSource.isPlaying)
            {
                yield return null;
            }

            // Small delay between spoken words
            yield return new WaitForSeconds(0.1f);
        }
    }
}
