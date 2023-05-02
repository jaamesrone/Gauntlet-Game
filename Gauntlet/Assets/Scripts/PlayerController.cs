using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    protected Vector3 moveInput;
    public float speed;
    private Rigidbody rigid;
    public int armor;
    public int magicPower;
    public int attackDamage;
    public GameObject weapon;
    public int maxHealth;
    private int currentHealth;


    protected float lastAttackTime=0;
    public float attackSpeed;//the small it is, the fast it can attack


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
       
        rigid.velocity = moveInput * speed;
    }

    protected bool CanAttack()
    {
        return Time.time - lastAttackTime >= attackSpeed;
    }

    protected virtual void Attack()
    {
        GameObject bullet = Instantiate(weapon, transform.position, Quaternion.identity, transform);
        bullet.GetComponent<Fireball>().direction = moveInput;
    }

    private void OnAttack(InputValue value)
    {
        if (CanAttack())
        {
            lastAttackTime = Time.time;
            Attack();
        }
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }
}
