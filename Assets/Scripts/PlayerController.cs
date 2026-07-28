using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5f;
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
            rb.AddForce(Vector3.down * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
