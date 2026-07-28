using UnityEngine;
using UnityEngine.InputSystem.Controls;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{
    public int obstacleHeightSpawnRange = 10;
    public float obstacleMinDimension = 2.0f;
    public float obstacleMaxDimension = 7.5f;
    public float obstacleSpeed = 10.0f;
    public float xLeftBound = -15.0f;
    public float xRightBound = 15.0f;
    public float spawnRateAcceleration = 1.0f;
    public float spawnRateDecreaseInterval = 20.0f;
    public float startingSpawnRate = 10.0f;
    public float minimumSpawnRate = 0.5f;
}
