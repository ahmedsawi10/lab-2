
using UnityEngine;

public class FollowerEnemy : EnemyController
{
    public Transform player;
    public float followSpeed = 2f;

    void FixedUpdate()
    {
        if (player == null)
            return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            followSpeed * Time.fixedDeltaTime
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats stats =
                other.GetComponent<PlayerStats>();

            if (stats != null)
                stats.TakeDamage(damage);
        }
        else if (other.CompareTag("Wall"))
        {
            Flip();
        }
    }
}
