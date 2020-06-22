using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BcgScroll : MonoBehaviour
{
    public float scrollSpeed;
    private new MeshRenderer renderer;
    private float quadHeight;
    private float quadWidth;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        quadHeight = Camera.main.orthographicSize * 2f;
        quadWidth = quadHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(quadWidth, quadHeight, 1);
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }
}
