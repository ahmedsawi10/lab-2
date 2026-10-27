
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 2f;
    public int damage = 1;
    public SpriteRenderer sr;

    protected virtual void Awake()
    {
        if (sr == null)
            sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void Flip()
    {
        if (sr != null)
            sr.flipX = !sr.flipX;
    }
}
