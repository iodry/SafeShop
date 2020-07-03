using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BcgScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float clampPos;
    private new MeshRenderer renderer;
    private float quadHeight;
    private float quadWidth;
    // Start is called before the first frame update
    void Start()
    {
        //Code with quad
        renderer = GetComponent<MeshRenderer>();
        quadHeight = Camera.main.orthographicSize * 2f;
        quadWidth = quadHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(quadWidth, quadHeight, 1);
    }

    // Update is called once per frame
    void Update()
    {

        //Code with quad
        renderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }
}
