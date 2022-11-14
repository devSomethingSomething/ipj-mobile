using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseXSensitivity;

    [SerializeField]
    private Transform player;

    private float mouseXInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseXInput = Input.GetAxisRaw("Mouse X") * mouseXSensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXInput);
    }
}
