using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private float speed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;

    // Ref: https://www.youtube.com/watch?v=r1dgRE0GM9A
    [Header("Footsteps")]
    [SerializeField]
    private AudioClip[] footstepAudioClips;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float stepSpeed;

    private float footstepTimer = 0.0f;

    private int footstepIndex = 0;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movementDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        characterController.Move(movementDirection * speed * Time.deltaTime);

        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        if (movementDirection != Vector3.zero)
        {
            footstepTimer -= Time.deltaTime;

            // Improve this velocity check later on
            var xVelocity = Mathf.Abs(characterController.velocity.x) > 3.0f;
            var zVelocity = Mathf.Abs(characterController.velocity.z) > 3.0f;

            if (footstepTimer <= 0.0f && (xVelocity || zVelocity))
            {
                audioSource.PlayOneShot(footstepAudioClips[footstepIndex]);

                // Alternate step sounds
                footstepIndex++;

                // Quick fix for steps
                audioSource.panStereo *= -1;

                if (footstepIndex == footstepAudioClips.Length)
                {
                    footstepIndex = 0;
                }

                footstepTimer = stepSpeed;
            }
        }
    }
}
