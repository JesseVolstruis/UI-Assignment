using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public SlotManager[] inventorySlots;
    public GameObject[] shopSlots;
    public string[] fText;
    public GameObject itemPrefab;
    public TextMeshProUGUI flavourText;

    private void Start()
    {
        fText[0] = "Name:Flamebrand\nPrice:$7\nSell Value:$5\n'Great for making terribly uneven toast'";

        fText[1] = "Name:Acid Cutter\nPrice:$6\nSell Value:$4\n'It's not really acid, just Monster and vodka'";

        fText[2] = "Name:Woodland Cutlass\nPrice:$8\nSell Value:$5\n'Definitely not a Terraria reference'";

        fText[3] = "Name:Mirror's Edge\nPrice:$5\nSell Value:$3\n'Can produce the perfect reflection for your GD assignment'";

        fText[4] = "Name:Shadowflame Katana\nPrice:$15\nSell Value:$10\n'The blade is edgier than the name\nDoesn't stack btw'";
        
        fText[5] = "Name:Cheese Knife\nPrice:$7\nSell Value:$6\n'Haggled from a humanoid rat. It's blunt'";

        fText[6] = "Name:Sword of Infinite Wealth\nPrice:$10\nSell Value:$15\n'Economic collapse is inevitable'";

        fText[7] = "Name:Sharpening Iron\nPrice:$3\nSell Value:$1\n'It's supposed to look like that, I promise\nStacks a lot btw'";
    }
    public bool AddItem(Item item)
    {
        //check if slot has same item for stacking purposes
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            SlotManager slot = inventorySlots[i];
            ItemManager itemInSlot = slot.GetComponentInChildren<ItemManager>();
            //checks if slot is occupied, is the same item, is below the max stack size and is stackable
            if (itemInSlot != null
                && itemInSlot.item == item
                && itemInSlot.itemCount < item.stackSize 
                && itemInSlot.item.isStackable == true)
            {
                itemInSlot.itemCount++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        //finds empty slot to add item to
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            SlotManager slot = inventorySlots[i];
            ItemManager itemInSlot = slot.GetComponentInChildren<ItemManager>();
            if(itemInSlot == null) 
            {
                SpawnItem(item, slot);
                return true;
            }
        }
        return false;
    }
    
    void SpawnItem(Item item, SlotManager slot)
    {
        //instantiates item in inventory slot
        GameObject newItem = Instantiate(itemPrefab, slot.transform);
        ItemManager inventoryItem = newItem.GetComponent<ItemManager>();
        inventoryItem.SetUpItem(item);
    }

    

   


}
