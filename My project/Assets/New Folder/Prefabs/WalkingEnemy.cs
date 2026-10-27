
using UnityEngine;

public class WalkingEnemy : EnemyController
{
    public Transform player;
    public float followSpeed = 2f;

    void FixedUpdate()
    {
        if (player == null)
            return;

        Vector2 targetPosition = player.position;

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            followSpeed * Time.fixedDeltaTime
        );

        if (sr != null)
        {
            sr.flipX = player.position.x < transform.position.x;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats playerStats =
            other.GetComponentInParent<PlayerStats>();

        if (playerStats == null)
        {
            playerStats =
                other.GetComponentInChildren<PlayerStats>();
        }

        if (playerStats != null)
        {
            playerStats.TakeDamage(damage);
            Debug.Log("Enemy damaged the Player!");
        }
    }
}
