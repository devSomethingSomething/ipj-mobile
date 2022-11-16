using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private bool enableTransport;

    [SerializeField]
    private string destinationRoom;

    [SerializeField]
    private string destinationInRoom;

    [SerializeField]
    private List<Word> words;

    public AudioClip AudioClip => audioClip;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && enableTransport)
        {
            SetDestinationInRoom();

            StartCoroutine(SoundManager.Instance.Say(
                new AudioClip[] { audioClip }.Concat(
                        WordManager.Instance.ConvertWordsToArray(words))
                            .ToArray(), LoadRoom));
        }
        else if (collider.CompareTag("Player") && !enableTransport)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
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
