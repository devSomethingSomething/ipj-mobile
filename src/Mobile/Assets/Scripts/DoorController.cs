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
            // Perhaps handle all messages here
            SoundManager.Instance.Play(audioClip);

            LoadRoom();
        }
    }

    private void LoadRoom()
    {
        SceneManager.LoadScene(destinationRoom);
    }
}
