using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    public GameObject[] itemsArray;
    private string currentItemPicked;
    public bool pickUpEvent = false;
    

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("PlayerManager initialized");

            itemsArray = GameObject.FindGameObjectsWithTag("Interactable");
/*        foreach (var item in itemsArray)
        {
            Debug.Log(item.name);
        }*/

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        player.GetComponent<Animator>().SetBool("Die", true);
    }

    public void React()
    {
        player.GetComponent<Animator>().SetTrigger("React");
    }

    public void PickUp()
    {
        player.GetComponent<Animator>().SetTrigger("PickUp");
    }
    public void PickUpAnim(string itemName)
    {
        player.GetComponent<ThirdPersonCharacter>().PickUp();//GetComponent<Animator>().SetTrigger("PickUp");
        currentItemPicked = itemName;
        //Debug.Log("PlayerMgr check");
        pickUpEvent = true;
    }

/*    public void TriggerPickUp()
    {
        if(currentItemPicked!=null)
        {
            //Debug.Log("item " + currentItemPicked);
            for (int i = 0; i < itemsArray.Length; i++)
            {
                if(itemsArray[i].name==currentItemPicked)
                {
                    itemsArray[i].GetComponent<PickItem>().PickUpItem();
                    //Debug.Log("From array triggered");
                    pickUpEvent = false;
                }
            }
        }
    }*/


}
