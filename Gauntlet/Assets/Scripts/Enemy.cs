using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float detectionRadius;

    private void Update()
    {
        // Check if the player is within the detection radius
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            // Move the enemy towards the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.timer -= 10;
        }
    }
}
