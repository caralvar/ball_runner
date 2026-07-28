using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public Settings settings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.x < settings.xLeftBound)
        {
            Destroy(gameObject);
        }
    }

    private void MoveObstacle()
    {
        transform.Translate(Vector3.left * settings.obstacleSpeed * Time.deltaTime);
    }
}
