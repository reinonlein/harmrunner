using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointTimeExtension = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = 0.2f;

    ObstacleSpawner obstacleSpawner;
    GameManager gameManager;

    const string playerString = "Player";

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerString)) return;

        gameManager.IncreaseTime(checkpointTimeExtension);
        obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
    }

}
