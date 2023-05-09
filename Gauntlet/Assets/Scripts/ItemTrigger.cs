using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public ItemName itemName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            if (other.GetComponent<PlayerController>().AddItem(itemName))
            {
                Destroy(gameObject);
            }
        }
    }
}
