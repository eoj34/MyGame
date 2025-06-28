using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform puck;
    public float speed = 4f;

    void Update()
    {
        if (puck == null) return;

        float targetY = puck.position.y;
        float step = speed * Time.deltaTime;

        transform.position = new Vector2(
            transform.position.x,
            Mathf.MoveTowards(transform.position.y, targetY, step)
        );
    }
}
