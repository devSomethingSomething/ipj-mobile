using UnityEngine;

public class ScraperController : MonoBehaviour
{
    [SerializeField]
    private AudioClip thudAudioClip;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Wall"))
        {
            AudioSource.PlayClipAtPoint(thudAudioClip, collider.transform.position, 0.3f);
        }
    }
}
