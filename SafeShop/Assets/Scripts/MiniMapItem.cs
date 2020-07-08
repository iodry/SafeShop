using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapItem : MonoBehaviour
{
    private Transform item;
    public Vector3 offset = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        item = transform.parent; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log(item.parent);
        transform.position = item.position + offset - new Vector3(0, transform.position.y,0);
        if (item.gameObject.activeSelf == false)
        {
            Destroy(transform.gameObject);
           // transform.gameObject.SetActive(false);
        }

    }
}
