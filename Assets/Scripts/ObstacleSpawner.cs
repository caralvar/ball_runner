using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Settings settings;
    public GameObject[] obstaclePrefabs;

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = settings.startingSpawnRate;
        StartCoroutine(SpawnRoutine());
        StartCoroutine(DecreaseSpawnRateRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }

    private IEnumerator DecreaseSpawnRateRoutine()
    {
        while (currentSpawnInterval > settings.minimumSpawnRate)
        {
            currentSpawnInterval -= settings.spawnRateAcceleration;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, settings.minimumSpawnRate);
            yield return new WaitForSeconds(settings.spawnRateDecreaseInterval);
        }
    }

    private void SpawnObstacle()
    {
        int obstacleToSpawnIndex = Random.Range(0, obstaclePrefabs.Length);
        float obstacleToSpawnHeight = Random.Range(0, settings.obstacleHeightSpawnRange);
        float obstacleWidth = Random.Range(settings.obstacleMinDimension, settings.obstacleMaxDimension);
        float obstacleHeight = Random.Range(settings.obstacleMinDimension, settings.obstacleMaxDimension);
        Vector3 spawnPosition = new Vector3(settings.xRightBound, obstacleToSpawnHeight, 0f);
        GameObject newObstacle = Instantiate(obstaclePrefabs[obstacleToSpawnIndex], 
                                             spawnPosition, 
                                             obstaclePrefabs[obstacleToSpawnIndex].transform.rotation);
        SpriteRenderer obstacleSpriteRenderer = newObstacle.GetComponent<SpriteRenderer>();
        Vector2 newObstacleDimensions = new Vector2(obstacleWidth, obstacleHeight);
        if (obstacleSpriteRenderer != null)
        {
            obstacleSpriteRenderer.size = newObstacleDimensions;
        }
        BoxCollider2D obstacleCollider = newObstacle.GetComponent<BoxCollider2D>();
        if (obstacleCollider != null)
        {
            obstacleCollider.size = newObstacleDimensions;
            obstacleCollider.offset = Vector2.zero;
        }
    }
}
