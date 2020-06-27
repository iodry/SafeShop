using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionProjector : MonoBehaviour
{
    public EnemyController controller;
    //public Transform player;
    //private float fieldOfView;
    
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponentInParent<EnemyController>();
        GetComponent<Projector>().fieldOfView = controller.lookRadius * 10;
        //Debug.Log("data=" + GetComponent<Projector>().fieldOfView);


    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = new Vector3(player.position.x, posY, player.position.z);
        
    }
}
