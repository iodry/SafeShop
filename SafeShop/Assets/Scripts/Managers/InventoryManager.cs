using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
     public TextMeshProUGUI[] shoppingList;
    public Inventory inventory;
   public InventoryUI invUI;
    private GameObject[] itemList;
    private List<IInventoryItem> checkOutInvList = new List<IInventoryItem>();

    // Start is called before the first frame update
    void Start()
    {
        itemList = GameObject.FindGameObjectsWithTag("Interactable");
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null)
            {
                shoppingList[i].text = itemList[i].name;
                shoppingList[i].enabled = true;
                shoppingList[i].gameObject.SetActive(true);
                shoppingList[i].GetComponentInChildren<Image>().sprite = itemList[i].GetComponent<Image>().sprite;
               // Debug.Log(shoppingList[i].text);
            }
            else
            {
                shoppingList[i].enabled = false;
                //Debug.Log("else");
            }
        }
        //Debug.Log("shoplist" + shoppingList.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckOutItems()
    {
        foreach (IInventoryItem invItem in inventory.mItems)
        {
           // Debug.Log(invItem.Name + " loop");
            checkOutInvList.Add(invItem);
            //Debug.Log(invItem.Name + " added");

            foreach (var item in shoppingList)
            {
                if (item.text == invItem.Name)
                {
                    item.fontStyle = FontStyles.Strikethrough;
                    //Debug.Log(invItem.Name + " condi");

                }
            }
        }
        inventory.mItems.Clear();
        invUI.RemoveItemsUI();
        if (itemList.Length - checkOutInvList.Count>0)
        {
            int remain = itemList.Length - checkOutInvList.Count;
            invUI.PopUpPanel("Checked out - still " + remain + " to check out!", 1.5f);
        }
        else
        {
           invUI.PopUpPanel("Checked out!",.75f);
        }
        
        CheckListComplete();
    }

    private void CheckListComplete()
    {
        //Debug.Log("shop list count = " + itemList.Length + "current checkout =" + checkOutInvList.Count);
        if (itemList.Length == checkOutInvList.Count)
        {
           // Debug.Log("Complete");
            GameManager.instance.CompleteLevel();
        }
    }
    public void StrikethroughItem(string itemName)
    {
        foreach (var item in shoppingList)
        {
            //Debug.Log("called "+item.text +" vs "+itemName);


            if (item.text==itemName)
            {
                item.fontStyle = FontStyles.Strikethrough;
                
            }
        }
    }
}
