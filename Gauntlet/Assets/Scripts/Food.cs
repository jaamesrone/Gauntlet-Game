using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    public void UseItem(PlayerController player)
    {
        player.Heal(20);
    }
}
