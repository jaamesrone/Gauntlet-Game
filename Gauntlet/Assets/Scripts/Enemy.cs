using UnityEngine;
public class Enemy : MonoBehaviour
{
    protected PlayerController targetPlayer;
    public float moveSpeed = 5f;
    public int health;
    public int enemyLevel;
    public float attackRange;
    protected float lastAttackTime=0;
    public float attackTimeGap;//determine the attackspeed of the enemy
    public int attackForce;
    protected Rigidbody rigid;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    protected virtual void Update()
    {
        targetPlayer = DetectPlayer();
        if (Vector3.Distance(transform.position,targetPlayer.transform.position)<= attackRange)
        {
            Attack();
        }
        else
        {
            Vector3 directionToPlayer = (targetPlayer.transform.position - transform.position).normalized;
           transform.position += directionToPlayer * moveSpeed *Time.deltaTime ;
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.timer -= 10;
        }
    }

    protected PlayerController DetectPlayer()
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

    protected virtual void Attack()
    {

    }
}
