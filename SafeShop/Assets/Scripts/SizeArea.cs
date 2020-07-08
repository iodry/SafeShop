using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeArea : MonoBehaviour
{
    public float ratioScale = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        float xyz = GetComponentInParent<EnemyController>().lookRadius * ratioScale;
        transform.localScale = new Vector3(xyz, xyz, xyz);
    }
}
