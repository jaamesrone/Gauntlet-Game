using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorHammaer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            int damage = GetComponentInParent<Warrior>().attackDamage;
            other.gameObject.GetComponent<Enemy>().Hurt(damage);
        }
        if (other.gameObject.tag == "EnemySpawner")
        {
            int damage = GetComponentInParent<Warrior>().attackDamage;
            other.gameObject.GetComponent<EnemySpawner>().Hurt(damage);
        }
    }
  
}
