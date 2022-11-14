using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Vector3 offset = new Vector3(0.0f, 1.5f, 0.0f);

    private void Awake()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (string.IsNullOrEmpty(Destination.DestinationInRoom))
        {
            Instantiate(player, offset, Quaternion.identity);
        }
        else
        {
            Transform transform = GameObject.Find(Destination.DestinationInRoom).transform;

            if (transform != null)
            {
                Instantiate(player, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(player, offset, Quaternion.identity);
            }

            Destination.ResetDestinationInRoom();
        }
    }
}
