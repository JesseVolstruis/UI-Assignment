using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item")] 
public class Item : ScriptableObject
{
    public Sprite image;
    public float price;
    public bool isStackable = true;
    public float sellValue;
    public int stackSize;
}

