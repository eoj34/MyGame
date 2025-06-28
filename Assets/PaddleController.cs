using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public enum Player { Player1, Player2 }
    public Player player = Player.Player1;

    public float speed = 5f;

    public float minX = -8f; // Clamp values for X position
    public float maxX = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveY = 0f;
        float moveX = 0f;

        if (player == Player.Player1)
        {
            if (Input.GetKey(KeyCode.W)) moveY = 1f;
            if (Input.GetKey(KeyCode.S)) moveY = -1f;

            if (Input.GetKey(KeyCode.D)) moveX = 1f;
            if (Input.GetKey(KeyCode.A)) moveX = -1f;
        }
        else if (player == Player.Player2)
        {
            if (Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;

            if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
            if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
        }

        rb.linearVelocity = new Vector2(moveX, moveY).normalized * speed;

        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}
