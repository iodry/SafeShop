using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    /*public GameManager gameManager;
    //public InventoryManager inventoryManager;
    public List<string> shoppingList = new List<string>();
    public List<string> memoryList = new List<string>();
    int countList = 0;

    private void Start()
    {
        //Add all pickable items in shopping list
        InitializeShoppingList();
    }

    //Add all pickable items in shopping list
    void InitializeShoppingList()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Interactable");
        foreach(GameObject i in items)
        {
            shoppingList.Add(i.name);
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag!= "Player")
        {
            if(memoryList.Contains(collider.name))
            {
                Destroy(collider);
*//*                inventoryManager.StrikethroughItem(collider.name);
                Debug.Log("STRIKE");*//*
            }
            else
            {
                if (shoppingList.Contains(collider.name))
                {
                    memoryList.Add(collider.name);
                    countList++;
                    

                    //Debug.Log("Count" + countList);
                    if (shoppingList.Count == countList)
                    {
                        FindObjectOfType<InventoryManager>().StrikethroughItem(collider.name);
                        gameManager.CompleteLevel();
                        foreach (var i in shoppingList)
                        {
                            Debug.Log("#" + i);
                        }
                    }
                    else
                    {
                        Destroy(collider);
                        FindObjectOfType<InventoryManager>().StrikethroughItem(collider.name);
                    }
                }
            }
            
        }

        
    }*/
}
