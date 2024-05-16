using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler
{
    public ShopManager shopManager;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject droppedItem = eventData.pointerDrag;
            ItemManager item = droppedItem.GetComponent<ItemManager>();
            item.AfterDrag = transform;
        }
    }
    public void UpdateFlavourText(int id)
    {
        shopManager.flavourText.text = shopManager.fText[id];
    }





}
