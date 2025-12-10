//using UnityEngine;

//public class ObstacleMover : MonoBehaviour
//{
//    public float moveSpeed = 5f;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        transform.position = transform.position + (Vector3.left + moveSpeed) * Time.deltaTime;
//    }
//}





// DIAGONAL
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
        rb = GetComponent<Rigidbody2D>();         // CACHE THE BODY
        // TIP: IF BODY TYPE = DYNAMIC, SET GRAVITY SCALE = 0.
        // TIP: ENABLE INTERPOLATION FOR EXTRA SMOOTHNESS.
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





// STRAIGHT
//using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//public class ObstacleMover : MonoBehaviour
//{
//    [SerializeField] float moveSpeed = 5f;   // UNITS PER SECOND

//    Rigidbody2D rb;

//    void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();    // CACHE THE BODY
//        // TIP: IF BODY TYPE = DYNAMIC, SET GRAVITY SCALE = 0.
//        // TIP: ENABLE INTERPOLATION FOR EXTRA SMOOTHNESS.
//    }

//    void FixedUpdate()
//    {
//        // MOVE STRAIGHT DOWN AT A CONSTANT SPEED (FRAME-RATE INDEPENDENT)
//        rb.MovePosition(rb.position + Vector2.down * moveSpeed * Time.fixedDeltaTime);
//    }
//}
