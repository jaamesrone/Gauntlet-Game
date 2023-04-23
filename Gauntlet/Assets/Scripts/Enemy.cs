using UnityEngine;
public class Enemy : MonoBehaviour
{
    private PlayerController targetPlayer;
    public float moveSpeed = 5f;
    public int health;

    private void Start()
    {
        
    }
    private void Update()
    {
        targetPlayer = DetectPlayer();
        Vector3 directionToPlayer = (targetPlayer.transform.position - transform.position).normalized;
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.timer -= 10;
        }
    }

    private PlayerController DetectPlayer()
    {
        float minDis = 1000000;
        PlayerController targetPlayer=null;
        for (int i = 0; i < GameManager.Instance.players.Count; i++)
        {
            float dis = Vector3.Distance(transform.position, GameManager.Instance.players[i].transform.position);
            if (dis<minDis)
            {
                targetPlayer = GameManager.Instance.players[i];
                minDis = dis;
            }
        }
        return targetPlayer;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
}
