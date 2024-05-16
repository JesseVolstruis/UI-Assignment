using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavourTextManager : MonoBehaviour
{
    public ShopManager shopManager;

    private void OnMouseOver()
    {
        for (int i = 0; i < shopManager.shopSlots.Length; i++)
        {
            if (shopManager.shopSlots[i] == this)
            {
                shopManager.flavourText.text = shopManager.fText[i];
            }
        }
        Debug.Log("Mouse activity detected!!!!!!!!!!");

    }
    
}
