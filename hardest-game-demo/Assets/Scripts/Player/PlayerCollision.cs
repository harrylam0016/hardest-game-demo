using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [Header("Death Settings")]
    [SerializeField] private float deathDelay = 1.0f;

    private bool isDead = false; // Prevent multiple triggers

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Enemy"))
        {
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        isDead = true;

        var playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.DisableMovement();
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayHitEnemySFX();
        }

        StartCoroutine(DeathEffect());

        StartCoroutine(RestartAfterDelay());
    }

    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneUtils.RestartCurrentScene();
    }

    private IEnumerator DeathEffect()
    {
        var renderer = GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            // Flash effect
            for (int i = 0; i < 5; i++)
            {
                renderer.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                renderer.color = Color.white;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private void Start()
    {
        isDead = false;
    }
}
