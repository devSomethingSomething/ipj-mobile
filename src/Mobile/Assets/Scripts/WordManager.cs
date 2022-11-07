using UnityEngine;

public class WordManager : MonoBehaviour
{
    public AudioClip Hello;
    public AudioClip World;

    public static WordManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
