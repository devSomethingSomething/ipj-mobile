using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private string destinationRoom;

    [SerializeField]
    private string destinationInRoom;

    [SerializeField]
    private List<Word> words;

    public AudioClip AudioClip => audioClip;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            SetDestinationInRoom();

            StartCoroutine(SoundManager.Instance.Say(
                new AudioClip[] { audioClip }.Concat(
                        WordManager.Instance.ConvertWordsToArray(words))
                            .ToArray(), LoadRoom));
        }
    }

    private void SetDestinationInRoom()
    {
        Destination.DestinationInRoom = destinationInRoom;
    }

    private void LoadRoom()
    {
        SceneManager.LoadScene(destinationRoom);
    }
}
