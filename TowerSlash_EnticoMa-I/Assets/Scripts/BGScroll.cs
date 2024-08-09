using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private Renderer bgFloor;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // code I got online for scrolling texture 
        bgFloor.material.mainTextureOffset += new Vector2(-speed * Time.deltaTime, 0);
    }
}
