using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Item item;
    [HideInInspector] public Transform AfterDrag;
    [HideInInspector] public Transform originalParent;
    [HideInInspector] public int itemCount = 1;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI shopText;
    public GameObject countSquare;
    public MoneyManager moneyManager;
    public GameObject[] toDeactivate;

    private void Start()
    {
        SetUpItem(item);
        moneyManager = GameObject.FindObjectOfType<MoneyManager>();
        originalParent = transform.parent;
        //countSquare = GameObject.FindGameObjectWithTag("SquareText");
       
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1)) //if right click, deactivate the sell button ui
        {
            foreach (GameObject obj in toDeactivate)
            {
                obj.SetActive(false); 
            }
        }
    }


    public void SetUpItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = itemCount.ToString();
        bool textActive = itemCount > 1;
        countText.gameObject.SetActive(textActive);
        countSquare.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (originalParent.parent.name != "ShopSlots")
        {
            Debug.Log("Bgin drag");
            AfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = worldPosition;
            Debug.Log("Item Position: " + transform.position);
        
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //checks if being dragged into shop, if not, its final position can change
        if(AfterDrag.parent.name != "ShopSlots")
        {
            Debug.Log("no Drag");
            transform.SetParent(AfterDrag);
        }
        else
        {
            transform.SetParent(originalParent);
        }
        image.raycastTarget = true;
        
    }

    public void SellItem ()
    {
        moneyManager.money += (item.sellValue * itemCount); //sells the whole stack of items
        moneyManager.noMoneyText.text = " "; //resets no money text
        Destroy(gameObject);
        
    }

    
    




}

