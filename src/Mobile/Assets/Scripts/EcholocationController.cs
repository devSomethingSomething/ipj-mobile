using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcholocationController : MonoBehaviour
{
    [SerializeField]
    private AudioClip testAudioClip;

    [SerializeField]
    private KeyCode echolocateKeyCode;

    [SerializeField]
    private LayerMask interactableLayerMask;

    private new Transform transform;

    private void Awake()
    {
        transform = gameObject.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(echolocateKeyCode))
        {
            StartCoroutine(Echolocate());
        }
    }

    private IEnumerator Echolocate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5.0f, interactableLayerMask);

        foreach (Collider collider in colliders)
        {
            Transform colliderTransform = collider.transform;

            if (Physics.Linecast(transform.position, colliderTransform.position, out RaycastHit raycastHit) && 
                raycastHit.transform.name == collider.name)
            {
                AudioSource.PlayClipAtPoint(testAudioClip, colliderTransform.position);
            }
        }

        yield return null;
    }
}
