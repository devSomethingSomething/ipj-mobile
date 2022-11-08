using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private string destinationRoom;

    [SerializeField]
    private List<Word> words;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            StartCoroutine(SoundManager.Instance.Say(
                new AudioClip[] { audioClip }.Concat(
                        WordManager.Instance.ConvertWordsToArray(words))
                            .ToArray()));

            LoadRoom();
        }
    }

    private void LoadRoom()
    {
        SceneManager.LoadScene(destinationRoom);
    }
}
