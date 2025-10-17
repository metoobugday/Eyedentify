using UnityEngine;

public class PlayerSimpleController : MonoBehaviour
{
    [Header("Speed")]
    public float moveSpeed = 5f;   // dünya birimi/saniye

    Rigidbody2D rb;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // WASD / Ok tuþlarý (Input Manager varsayýlan eksenleri)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        input = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
}
