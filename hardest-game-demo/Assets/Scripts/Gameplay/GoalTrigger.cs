using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    [Header("Goal Settings")]
    [SerializeField] private float completionDelay = 1.5f;

    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered) return;

        if (other.CompareTag("Player"))
        {
            isTriggered = true;

            var playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.DisableMovement();
            }

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayWinGoalSFX();
            }

            StartCoroutine(LoadNextAfterDelay());
        }
    }

    private IEnumerator LoadNextAfterDelay()
    {
        yield return new WaitForSeconds(completionDelay);
        SceneUtils.LoadNextScene();
    }
}