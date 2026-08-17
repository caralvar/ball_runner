using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Settings settings;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.down * settings.playerJumpForce, ForceMode2D.Impulse);
        }
        float xForce = settings.playerXForce * (settings.playerXPositionRightLimit - transform.position.x);
        xForce = math.clamp(xForce, -1 * settings.playerMaxXForce, settings.playerMaxXForce);
        rb.AddForce(Vector2.right * xForce, ForceMode2D.Force);
    }

    private void ClampRightPosition()
    {
        if (transform.position.x > settings.playerXPositionRightLimit)
        {
            Vector2 clampedPosition = transform.position;
            clampedPosition.x = settings.playerXPositionRightLimit;
            transform.position = clampedPosition;
            rb.linearVelocityX = 0f;
        }
    }
}
