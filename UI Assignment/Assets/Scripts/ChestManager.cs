using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public GameObject chestSlot;
    public GameObject upgradeButton;
    public MoneyManager moneyManager;
   public void UpgradeChest()
    {
        if (moneyManager.money >= 30)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject newChestSlot = Instantiate(chestSlot, transform);
            }
            upgradeButton.SetActive(false);
            moneyManager.money -= 30;
        }
        else
        {
            moneyManager.noMoneyText.text = "Sorry, you're broke :(";
        }

    }

    
}
