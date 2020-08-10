using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapItem : MonoBehaviour
{
    private Transform item;
    public Vector3 offset = new Vector3();
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        item = transform.parent;
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = GetComponentInParent<Image>().sprite;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log(item.parent);
       // transform.position = item.position + offset - new Vector3(0, transform.position.y,0);
        if (item.gameObject.activeSelf == false)
        {
            Destroy(transform.gameObject);
           // transform.gameObject.SetActive(false);
        }

    }
}
