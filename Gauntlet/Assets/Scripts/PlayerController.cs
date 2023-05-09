using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    protected Vector3 moveInput;
    public float speed;
    private Rigidbody rigid;

    public int upgradePotions;//
    public int potions;//
    public int keys;//

    public int score;
    public int armor;
    public int magicPower;
    public int attackDamage;
    public GameObject weapon;
    public int maxHealth;
    private int currentHealth;
    public Text scoreText;
    public Text healthText;

    protected float lastAttackTime = 0;
    public float attackSpeed; // The smaller it is, the faster the player can attack

    protected Item[] items = new Item[2] { null ,null};
    Image[] itemImage;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthText.text = "Health: " + maxHealth;
        scoreText.text = "Score: " + 0;
        itemImage = transform.Find("Canvas").Find("Item").GetComponentsInChildren<Image>();
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
        Fireball b = bullet.GetComponent<Fireball>();
        b.direction = moveInput;
        b.shootedByPlayer = true;
    }

    private void OnAttack(InputValue value)
    {
        if (CanAttack())
        {
            lastAttackTime = Time.time;
            Attack();
        }
    }

    private void OnUsingFirstItem(InputValue value)
    {
        if (items[0]!=null)
        {
            items[0].UseItem(this);
            items[0] = null;
            itemImage[0].sprite = Resources.Load<Sprite>("Sprites/null");
        }
    }

    private void OnUsingSecondItem(InputValue value)
    {
        if (items[1] != null)
        {
            items[1].UseItem(this);
            items[1] = null;
            itemImage[1].sprite = Resources.Load<Sprite>("Sprites/null");
        }
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        healthText.text = "Health: " + currentHealth;
    }

    public void ChangeScore(int points)//
    {
        score += points;
        if (score<0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }

    public void BeStole()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i]!=null)
            {
                items[i] = null;
                itemImage[i].sprite= Resources.Load<Sprite>("Sprites/null");
                break;
            }
            if (i==1)
            {
                ChangeScore(-250);
            }
        }
    }

    public bool AddItem(ItemName itemName)
    {
        int addItemIndex=-1;
      
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i]==null)
            {
                addItemIndex = i;
                break;
            }
        }
        if (addItemIndex==-1)
        {
            return false;
        }
        switch (itemName)
        {
            case ItemName.Food:
                Item food = new Food();
                items[addItemIndex] = food;
                itemImage[addItemIndex].sprite = Resources.Load<Sprite>("Sprites/Food");
                break;
            case ItemName.Potion:
                Item potion = new Potion();
                items[addItemIndex] = potion;
                itemImage[addItemIndex].sprite = Resources.Load<Sprite>("Sprites/Potion");
                break;
            default:
                break;
        }
        return true;
    }



    public void Heal(int addHealth)
    {
        currentHealth += addHealth;
        if (currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = "Health: " + currentHealth;
    }

    public virtual void UseMagicPotion()
    {

    }
}
