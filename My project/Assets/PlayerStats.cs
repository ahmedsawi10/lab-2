
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;

    public bool isImmune = false;
    public float immunityDuration = 1.5f;

    private float immunityTime = 0f;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isImmune)
            return;

        health -= damage;

        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            health = 0;

            if (lives > 0)
            {
                LevelManager levelManager =
                    FindObjectOfType<LevelManager>();

                if (levelManager != null)
                {
                    levelManager.RespawnPlayer(gameObject);
                    lives--;
                    health = 3;
                }
                else
                {
                    Debug.LogError("LevelManager not found!");
                }
            }
            else
            {
                Debug.Log("Gameover");
                Destroy(gameObject);
                return;
            }
        }

        isImmune = true;
        immunityTime = 0f;
        flickerTime = 0f;
    }

    void Update()
    {
        if (!isImmune)
            return;

        immunityTime += Time.deltaTime;
        flickerTime += Time.deltaTime;

        if (sr != null && flickerTime >= flickerDuration)
        {
            sr.enabled = !sr.enabled;
            flickerTime = 0f;
        }

        if (immunityTime >= immunityDuration)
        {
            isImmune = false;

            if (sr != null)
                sr.enabled = true;
        }
    }
}
