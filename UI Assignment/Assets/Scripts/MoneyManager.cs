using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI noMoneyText;
    [SerializeField]
    public float money;

    private void Update()
    {
        //updates text to be equal to current money
        moneyText.text = "$"+money.ToString();
    }

    public void BuyItem(float price)
    {
        //decreases money according to purchased item
        noMoneyText.text = "";
        money -= price;
    }

    public void NoMoney()
    {
        //shows text for insufficient money
        noMoneyText.text = "Sorry, you're broke :(";
    }
}


