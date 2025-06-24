using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComplexEnemy : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float waitTime = 1f;

    private int currentWaypoint = 0;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    void Update()
    {
        if (waypoints.Length == 0) return;

        if (!isWaiting)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                isWaiting = true;
                waitTimer = waitTime;
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            }
        }
        else
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f) isWaiting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.FreezeMovement();
                other.gameObject.SetActive(false);

                if (GameManager.Instance != null)
                {
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.Lose);
                    GameManager.Instance.PlayerFailed();
                }
                else
                {
                    Debug.LogError("GameManager.Instance es null");
                }
            }
        }
    }
}
