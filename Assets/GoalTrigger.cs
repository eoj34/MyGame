
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isLeftGoal; // true = left goal (so Player 2 scores)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            Debug.Log(isLeftGoal ? "Goal for Player 2!" : "Goal for Player 1!");

            // ✅ ADD THIS LINE:
            GameManager.Instance.AddScore(!isLeftGoal);

            // Reset puck to center and relaunch
            other.transform.position = Vector2.zero;
            other.attachedRigidbody.linearVelocity = Vector2.zero;

            // Relaunch the puck
            PuckController puck = other.GetComponent<PuckController>();
            puck.Invoke("Launch", 0.5f); // small delay
        }
    }
}
