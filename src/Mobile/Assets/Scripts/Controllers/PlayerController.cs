using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private AudioClip footstepAudioClip;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float stepSpeed;

    private AudioSource audioSource;

    private CharacterController characterController;

    private float footstepTimer;

    private Vector3 movementDirection;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandlePlayerMovement();

        HandleFootsteps();
    }

    private void HandlePlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        characterController.Move(movementDirection * speed * Time.deltaTime);
    }

    private void HandleFootsteps()
    {
        if (movementDirection != Vector3.zero)
        {
            footstepTimer -= Time.deltaTime;

            // Improve this velocity check later on
            bool canStep = characterController.velocity.magnitude >= (speed - 2.0f);

            if (footstepTimer <= 0.0f && canStep)
            {
                audioSource.PlayOneShot(footstepAudioClip);

                // Quick fix for step sounds
                audioSource.panStereo *= -1;

                footstepTimer = stepSpeed;
            }
        }
    }
}
