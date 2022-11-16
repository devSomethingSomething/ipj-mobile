using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (string.IsNullOrEmpty(Destination.DestinationInRoom))
        {
            Instantiate(player, Vector3.zero, Quaternion.identity);
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
                Instantiate(player, Vector3.zero, Quaternion.identity);
            }

            Destination.ResetDestinationInRoom();
        }
    }
}
