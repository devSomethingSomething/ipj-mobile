using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    // 1. Add words here
    public AudioClip Hello;
    public AudioClip World;

    public static WordManager Instance { get; private set; }

    private List<AudioClip> words;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);

        // 2. Here as well
        words = new List<AudioClip>();
        words.Add(Hello);
        words.Add(World);
    }

    public AudioClip[] ConvertWordsToArray(List<Word> words)
    {
        var audioClips = new List<AudioClip>();

        foreach (Word word in words)
        {
            audioClips.Add(this.words[(int)word]);
        }

        return audioClips.ToArray();
    }
}

// 3. And lastly here
public enum Word
{
    Hello,
    World
}
