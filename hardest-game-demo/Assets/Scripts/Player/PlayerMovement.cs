using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    Rigidbody2D rb;
    Vector2 move;

    private bool canMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        if (canMove)
        {
            move = value.Get<Vector2>();
        }
        else
        {
            move = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.linearVelocity = move.normalized * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
        move = Vector2.zero;
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }

    void Start()
    {
        canMove = true;
    }
}
