using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerManager playerManager;
    public Inventory inventory;
    //public FixedButton aButton;
    private IInventoryItem itemInv = null;
    public InventoryUI invPan;
    public InventoryManager inventoryManager;
    private bool inCheckOut;
/*    public void StartPicking()
    {
        if (itemInv != null)
        {
            inventory.AddItem(itemInv);
            Debug.Log("Collider input");
        }
        itemInv = null;
        // PlayerManager.instance.TriggerPickUp();

    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ButtonOnClickActions();
        }
        //To play with keyboard for testing
            /*        if (itemInv != null && (Input.GetKeyDown(KeyCode.C)))
                    {
                        if (inventory.mItems.Count < inventory.slotNumber)
                        {
                            PlayerManager.instance.PickUp();
                            inventory.AddItem(itemInv);
                            //itemInv.OnPickup();
                            invPan.CloseMessagePanel();
                            itemInv = null;
                            invPan.PopUpPanel("Picked Up", .75f);
                            //Debug.Log("Pressed");
                        }
                    }
                    //Action to check out items
                    else if (inCheckOut && (Input.GetKeyDown(KeyCode.C)))
                    {
                        //Debug.Log("Called");
                        inventoryManager.CheckOutItems();
                    }*/
    }
    
    public void ButtonOnClickActions()
    {
        //For pick items and add to inventory list
        if (itemInv != null)
        {
            if (inventory.mItems.Count < inventory.slotNumber)
            {
                PlayerManager.instance.PickUp();
                inventory.AddItem(itemInv);
                //itemInv.OnPickup();
                invPan.CloseMessagePanel();
                invPan.PopUpPanel("Picked Up", .75f);
                itemInv = null;
            }
        }
        //Action to check out items
        else if (inCheckOut)
        {
            //Debug.Log("In loop");
            inventoryManager.CheckOutItems();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        IInventoryItem item = other.GetComponentInParent<IInventoryItem>();
        if (item != null)
        {
            if (inventory.mItems.Count < inventory.slotNumber)
            {
                invPan.OpenMessagePanel("Pick up");
            }
            else
            {
                invPan.OpenMessagePanel("Too many items on hand");
            }

            itemInv = item;
        }
        else if (other.name == "Checkout")
        {
            invPan.OpenMessagePanel("Proceed to checkout");
            inCheckOut = true;
            //Debug.Log("Checkout active");
        }


    }

    private void OnTriggerExit(Collider other)
    {
        IInventoryItem item = other.GetComponentInParent<IInventoryItem>();
        if (item != null)
        {
            invPan.CloseMessagePanel();
            itemInv = null;
        }
        else if (other.name == "Checkout")
        {
            invPan.CloseMessagePanel();
            inCheckOut = false;
        }
    }

    public void Pick(IInventoryItem item)
    {
        if (item != null)
        {
            inventory.AddItem(item);
            Debug.Log("Collider input");
        }
    }
}
