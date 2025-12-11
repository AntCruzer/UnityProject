// VERSION: DIAGONAL MOVEMENT

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RockMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;        // UNITS PER SECOND
    [Range(-1f, 1f)]
    [SerializeField] float horizontalDrift = -0.3f; // NEGATIVE = LEFT, POSITIVE = RIGHT (SMALL MAGNITUDES = SLIGHT DRIFT)

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();         // CACHE THE RIGIDBODY
    }

    void FixedUpdate()
    {
        // BUILD A DIRECTION BY ADDING VECTORS (VECTOR + VECTOR IS OK)
        // DOWN + (RIGHT * DRIFT), THEN NORMALIZE TO KEEP CONSISTENT SPEED.
        Vector2 dir = (Vector2.down + Vector2.right * horizontalDrift).normalized;

        // MOVE USING RIGIDBODY2D.MOVEPOSITION FOR PHYSICS-FRIENDLY MOTION
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }
}