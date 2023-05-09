using UnityEngine;
using System.Collections;

public class Valkyrie : PlayerController
{
    public override void UseMagicPotion()
    {
       
        for (int i = GameManager.Instance.enemys.Count - 1; i >= 0; i--)
        {
            Enemy e = GameManager.Instance.enemys[i];
            if (e != null)
            {
                if ((e.enemyLevel <= 2 || e.isDeath) && Vector3.Distance(transform.position, e.transform.position) <= 15)
                {
                    GameManager.Instance.enemys.Remove(e);
                    e.Dead();
                }
            }
        }
      
    }



}
