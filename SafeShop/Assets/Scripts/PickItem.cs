using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public GameObject player;
    public float throwForce = 10f;
    public float minDist = 1.9f;
    public FixedButton aButton;

    public Vector3 pickUpPosition;
    public Vector3 pickUpRotation;

    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;
    private bool playerIsHolding = false;
    private string itemPickedUp;

    public SpriteRenderer spriteLocator;

    // Start is called before the first frame update
    void Start()
    {
/*        if(GetComponentInChildren<SpriteRenderer>())
        {
            spriteLocator = GetComponentInChildren<SpriteRenderer>();
            Debug.Log("SPRITE");
        }*/
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //Check distance between item and player
        float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        bool actionButtonPressed = aButton.Pressed || Input.GetKey(KeyCode.C);

        foreach (Transform item in player.transform)
        {
            if(item.tag == ("Interactable"))
            {
                //Debug.Log("PICKUP " + item.name);
                itemPickedUp = item.name;
                playerIsHolding = true;
            }
        }

            //Check is item is in pickable range
        if (dist <= minDist)
            {
                hasPlayer = true;
            }
        else
            {
                hasPlayer = false;
            }

        //Input to pick up
        if (actionButtonPressed)
            {
            
            //Check if Player in range and free of item to begin pick up
            if (hasPlayer && !playerIsHolding)
                {

                if(PlayerManager.instance.pickUpEvent==false)
                {
                    PlayerManager.instance.PickUpAnim(this.name);
                    PlayerManager.instance.pickUpEvent = true;

                }
                
                
                //PickUpItem();
/*                GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<BoxCollider>().enabled = false;

                transform.parent = player.transform;
                GetComponent<Rigidbody>().transform.localPosition = pickUpPosition;
                GetComponent<Rigidbody>().transform.localEulerAngles = pickUpRotation;
                beingCarried = true;*/

                }
            //Player in range and carrying item. If item is already picked up do same previous condition to keep item
            else if (hasPlayer && playerIsHolding && this.GetComponent<Rigidbody>().name==itemPickedUp)
                {
                GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<BoxCollider>().enabled = false;
                transform.parent = player.transform;
                GetComponent<Rigidbody>().transform.localPosition = pickUpPosition;
                GetComponent<Rigidbody>().transform.localEulerAngles = pickUpRotation;
                beingCarried = true;
                spriteLocator.enabled = false;
            } 
            //If Player carrying item different from pickable item - do nothing for item
            else if (hasPlayer && playerIsHolding && this.GetComponent<Rigidbody>().name != itemPickedUp)
                {
                beingCarried = true;
                }


        }
        //Item being carried
        if (beingCarried)
            {
                //Check if carried item touch collider
                if (touched)
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    beingCarried = false;
                    touched = false;
                spriteLocator.enabled = true;
                //Debug.Log("TOUCHED");
            }
                //Drop off item
                else if (actionButtonPressed == false)
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    this.GetComponent<BoxCollider>().enabled = true;
                    transform.parent = null;
                    beingCarried = false;
                    touched = false;
                    playerIsHolding = false;
                spriteLocator.enabled = true;
            }
            }
        

    }

    public void PickUpItem()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<BoxCollider>().enabled = false;

        transform.parent = player.transform;
        GetComponent<Rigidbody>().transform.localPosition = pickUpPosition;
        GetComponent<Rigidbody>().transform.localEulerAngles = pickUpRotation;
        beingCarried = true;
        //Debug.Log("Methode Pick up called" );
    }
    void OnTriggerEnter(Collider collider)
    {
       // Debug.Log("Trigger with" + collider.name);
        if (beingCarried)
        {
            //if(collider = endZone.)
            touched = true;
           // Debug.Log("Trigger collision");
        }
    }
}
