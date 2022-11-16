using UnityEngine;

public class AreaController : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}
