using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();//contain the kind of item, not the number of items
    private Dictionary<InventoryData, InventoryItem> itemDictionary = new Dictionary<InventoryData, InventoryItem>();

    //private void OnEnable()
    //{
    //    TreasureBag.OnTreasureBagCollected += Add;
    //}

    //private void OnDisable()
    //{
    //    TreasureBag.OnTreasureBagCollected -= Add;
    //}

    public void Add(InventoryData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();// increase the size interger of the item
            Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added{itemData.displayName} to the inventory for the first time.");
        }
    }

    public void Remove(InventoryData itemData)
    {
        if (itemDictionary.TryGetValue(itemData,out InventoryItem item))
        {
            item.RemoveFromStack();
            if (item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //ICollectable collectable = other.GetComponent<ICollectable>();
        //if (collectable != null&&inventory.Count<2)
        //{
        //    // collectable.Collect();
        //    InventoryItem newItem = new InventoryItem(itemData);
        //    inventory.Add(newItem);
        //}
    }
}
