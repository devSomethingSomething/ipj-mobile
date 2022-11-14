using UnityEngine;

public class ScraperController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Wall"))
        {
            Debug.Log("Hit");

            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Wall"))
        {
            Debug.Log("Leave");

            audioSource.Stop();
        }
    }
}
