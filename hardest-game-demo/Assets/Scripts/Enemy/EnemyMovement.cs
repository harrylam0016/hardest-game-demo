using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum MoveType
    {
        PingPong,
        Circular
    }

    [Header("General Settings")]
    [SerializeField] MoveType moveType = MoveType.PingPong;
    [SerializeField] float moveSpeed = 3f;

    [Header("PingPong Settings")]
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    private Vector3 target;

    [Header("Circular Settings")]
    [SerializeField] Transform center;
    [SerializeField] float radius = 2f;
    private float angle;

    void Start()
    {
        if (moveType == MoveType.PingPong && pointA != null && pointB != null)
            target = pointB.position;
    }

    void Update()
    {
        switch (moveType)
        {
            case MoveType.PingPong:
                MovePingPong();
                break;

            case MoveType.Circular:
                MoveCircular();
                break;
        }
    }

    private void MovePingPong()
    {
        if (pointA == null || pointB == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    private void MoveCircular()
    {
        if (center == null) return;

        angle += moveSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = center.position + new Vector3(x, y, 0f);
    }
}
