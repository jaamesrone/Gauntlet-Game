using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveInput;
    public float speed;
    private Rigidbody rigid;
    public int armor;
    public int magicPower;
    public int attackDamage;

    
    protected float lastAttackTime=0;
    public float attackSpeed;//the small it is, the fast it can attack


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
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

    protected virtual IEnumerator Attack()
    {
        yield return null;
    }

    private void OnAttack(InputValue value)
    {
        if (CanAttack())
        {
            lastAttackTime = Time.time;
            StartCoroutine(Attack());
        }
    }
}
