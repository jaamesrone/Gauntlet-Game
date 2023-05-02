using UnityEngine;
using System.Collections;


public class Fireball : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifetime = 2.0f;
    public Vector3 direction;
    

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
        if (other.gameObject.tag == "Enemy")
        {
            int damage = GetComponentInParent<PlayerController>().attackDamage;
            other.gameObject.GetComponent<Enemy>().Hurt(damage);
        }
    }
}
