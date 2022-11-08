using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private string destinationRoom;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            StartCoroutine(SoundManager.Instance.Say(new AudioClip[]
            {
                audioClip,
                // Add a way of choosing words to say for room entry
                WordManager.Instance.Hello,
                WordManager.Instance.World
            }));

            LoadRoom();
        }
    }

    private void LoadRoom()
    {
        SceneManager.LoadScene(destinationRoom);
    }
}
