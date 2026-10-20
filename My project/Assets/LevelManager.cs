
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform currentCheckpoint;

    public void RespawnPlayer(GameObject player)
    {
        if (currentCheckpoint != null)
        {
            player.transform.position = currentCheckpoint.position;
        }
    }
}
