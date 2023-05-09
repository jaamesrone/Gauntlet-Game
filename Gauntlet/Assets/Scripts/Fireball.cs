using UnityEngine;
using System.Collections;


public class Fireball : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifetime = 2.0f;
    public Vector3 direction;
    public bool shootedByPlayer;
    public bool shootedByLobber;
    

    private float timer;

    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        // Move the fireball up
        if (direction==Vector3.zero)
        {
            direction = Vector3.up;
        }
        transform.Translate(direction * speed * Time.deltaTime);

        // Increment the timer
        timer += Time.deltaTime;

        // Destroy the fireball after its lifetime is up
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!shootedByLobber&&other.gameObject.tag=="Wall")
        {
            Destroy(gameObject);
        }
        if (shootedByPlayer)
        {
            int damage = GetComponentInParent<PlayerController>().attackDamage;
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().Hurt(damage);
                Destroy(gameObject);

            }
            if (other.gameObject.tag=="EnemySpawner")
            {
                other.gameObject.GetComponent<EnemySpawner>().Hurt(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.gameObject.tag=="Player")
            {
                int damage = GetComponentInParent<Enemy>().attackForce;
                other.gameObject.GetComponent<PlayerController>().Hurt(damage);
                Destroy(gameObject);

            }
        }
    }
}
