// ADJUSTED PLAYABLE BOUNDARIES

// REFERENCES
using UnityEngine;

// CLASS
public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 input;

    // SCREEN BOUNDS (WORLD SPACE)
    private float minX, maxX, minY, maxY;


    // INITIALIZE
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;                                       // TOP-DOWN: NO GRAVITY
        rb.freezeRotation = true;                                   // NO SPIN
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;    // SMOOTHER

        SETUP_SCREEN_BOUNDS();
    }


    // CALCULATE SCREEN BOUNDS BASED ON MAIN CAMERA
    void SETUP_SCREEN_BOUNDS()
    {
        Camera cam = Camera.main;                                   // GET MAIN CAMERA
        if (cam == null)                                            // SAFETY CHECK
        {
            Debug.LogError("NO MAIN CAMERA FOUND FOR PLAYER BOUNDS!");
            return;
        }

        // ORTHOGRAPHIC CAMERA SIZE:
        // HALF HEIGHT = ORTHOGRAPHICSIZE
        // HALF WIDTH  = HALF HEIGHT * ASPECT RATIO
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        // OPTIONAL: ACCOUNT FOR SPRITE SIZE SO IT DOESN'T CLIP OFF-SCREEN
        float paddingX = 0f;
        float paddingY = 0f;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            // BOUNDS.EXTENTS = HALF SIZE OF SPRITE IN WORLD UNITS
            paddingX = sr.bounds.extents.x;
            paddingY = sr.bounds.extents.y;
        }

        Vector3 camPos = cam.transform.position;                    // CAMERA CENTER POSITION

        // FINAL BOUNDS (WORLD SPACE)
        minX = camPos.x - halfWidth + paddingX;
        maxX = camPos.x + halfWidth - paddingX;
        minY = camPos.y - halfHeight + paddingY;
        maxY = camPos.y + halfHeight - paddingY;
    }


    // INPUT EVENTS
    void Update()
    {
        // READ INPUT IN UPDATE FOR RESPONSIVENESS
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input = Vector2.ClampMagnitude(input, 1f);                  // NORMALIZE DIAGONALS
    }


    void FixedUpdate()
    {
        // PHYSICS-FRIENDLY TRANSLATION
        Vector2 next = rb.position + input * speed * Time.fixedDeltaTime;

        // CLAMP POSITION SO WE STAY INSIDE SCREEN
        next.x = Mathf.Clamp(next.x, minX, maxX);
        next.y = Mathf.Clamp(next.y, minY, maxY);

        rb.MovePosition(next);
    }
}