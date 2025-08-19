using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    Rigidbody2D rb;
    Vector2 move;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move.normalized * moveSpeed;
    }
}
