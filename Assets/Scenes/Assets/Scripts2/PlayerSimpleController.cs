using UnityEngine;

public class PlayerSimpleController : MonoBehaviour
{
    [Header("Speed")]
    public float moveSpeed = 5f;   // d�nya birimi/saniye

    Rigidbody2D rb;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // WASD / Ok tu�lar� (Input Manager varsay�lan eksenleri)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        input = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
}
