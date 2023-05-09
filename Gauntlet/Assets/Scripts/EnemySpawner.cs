using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime;
    public int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, spawnTime);
        currentHealth = maxHealth;
    }

   private void SpawnEnemy()
    {
       GameManager.Instance.enemys.Add( Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<Enemy>());
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        if (currentHealth<=0)
        {
            CancelInvoke();
            Destroy(gameObject);
        }
    }
}
