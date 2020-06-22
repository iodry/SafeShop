using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetRoamingPostion()
    {
        return StartPosition + GetRandomDirection() * Random.Range(10f, 20f);
    }
    
    //Utilities
    public static Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
