using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuyButtonManager : MonoBehaviour
{
    public ShopManager shopManager;
    public Item[] itemsToMove;
    public MoneyManager moneyManager;

    public void MoveItem(int id)
    {
        //only adds item if there is enough money
        if (moneyManager.money >= itemsToMove[id].price)
        {
            bool result = shopManager.AddItem(itemsToMove[id]);
            if (result == true)
            {
                Debug.Log("You did a purchase :)");
            }
            else
            {
                Debug.Log("No purchases bub :(");
            }
            moneyManager.BuyItem(itemsToMove[id].price);
            moneyManager.noMoneyText.text = " ";
        }
        else
        {
            //when money is insufficient 
            moneyManager.NoMoney();
        }
    
    }
    


}
