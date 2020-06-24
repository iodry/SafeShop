using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInv : MonoBehaviour, IInventoryItem
{
    public string Name { get { return transform.name; } }

    //public Sprite i_Image = null;

    public Sprite Image { get { return transform.GetComponent<Image>().sprite; } }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
