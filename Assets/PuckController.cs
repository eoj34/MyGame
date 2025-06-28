using UnityEngine;

public class PuckController : MonoBehaviour
{
    public float speed = 5f;          // Initial speed
    public float minSpeed = 5f;       // Never go slower than this
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        Vector2 dir = new Vector2(x, y).normalized;
        rb.linearVelocity = dir * speed;
    }

    void Update()
    {
        // Clamp speed if it drops below minSpeed
        if (rb.linearVelocity.magnitude < minSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * minSpeed;
        }
    }

    void FixedUpdate()
{
    // Always keep a minimum angle so the puck doesn't get stuck moving only vertically or horizontally
    if (Mathf.Abs(rb.linearVelocity.x) < 0.1f)
    {
        rb.linearVelocity = new Vector2(
            Mathf.Sign(rb.linearVelocity.x) == 0 ? 1 : Mathf.Sign(rb.linearVelocity.x),
            rb.linearVelocity.y
        );
        rb.linearVelocity += new Vector2(Random.Range(0.2f, 0.5f), 0);
    }

    if (Mathf.Abs(rb.linearVelocity.y) < 0.1f)
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            Mathf.Sign(rb.linearVelocity.y) == 0 ? 1 : Mathf.Sign(rb.linearVelocity.y)
        );
        rb.linearVelocity += new Vector2(0, Random.Range(0.2f, 0.5f));
    }

    // Maintain overall speed if needed
    float minSpeed = 3f;
    if (rb.linearVelocity.magnitude < minSpeed)
    {
        rb.linearVelocity = rb.linearVelocity.normalized * minSpeed;
    }
}

}
