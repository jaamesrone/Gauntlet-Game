using UnityEngine;

public class Thieves : Enemy
{
    public int damage = 10;

    protected override void Update()
    {
        base.Update();
        if (targetPlayer != null)
        {
            //follow the player with the highest score uwu
            float maxScore = 0;
            foreach (PlayerController player in GameManager.Instance.players)
            {
                if (player.score > maxScore)
                {
                    maxScore = player.score;
                    targetPlayer = player;
                }
            }
        }
    }

    protected override void Attack()
    {
        // tang's weapon attack
        if (Time.time - lastAttackTime >= attackTimeGap)
        {
            //thief steals from players
            if (targetPlayer != null)
            {
                if (targetPlayer.upgradePotions > 0)
                {
                    targetPlayer.upgradePotions--;
                }
                else if (targetPlayer.potions > 0)
                {
                    targetPlayer.potions--;
                }
                else if (targetPlayer.keys > 0)
                {
                    targetPlayer.keys--;
                }
                else if (targetPlayer.score > 0)
                {
                    targetPlayer.score--;
                }
            }

            // thief does damage
            if (targetPlayer != null)
            {
                targetPlayer.Hurt(damage);
            }

            // checks for the last attack time uwu
            lastAttackTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if Thief tone is heard
        if (other.gameObject.tag == "ThiefTone")
        {
            // drops a trasure bag,.
            GameObject treasureBag = Instantiate(GameManager.Instance.treasureBagPrefab, transform.position, Quaternion.identity);
            treasureBag.GetComponent<TreasureBag>().points = 500;

           
            Destroy(gameObject);
        }
    }
}
