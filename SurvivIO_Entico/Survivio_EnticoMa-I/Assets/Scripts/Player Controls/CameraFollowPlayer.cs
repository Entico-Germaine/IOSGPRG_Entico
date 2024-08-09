using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public BoxCollider2D mapBounds;
    [SerializeField]
    public Camera mainCamera;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private float camX;
    private float camY;
    private float camRatio;
    private float screenAspect;
    private float camOrthSize;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 1, -5);

        minX = mapBounds.bounds.min.x;
        maxX = mapBounds.bounds.max.x;
        minY = mapBounds.bounds.min.y;
        maxY = mapBounds.bounds.max.y;

        camOrthSize = mainCamera.orthographicSize;
        screenAspect = (float)Screen.width / (float)Screen.height;
        camRatio = screenAspect * camOrthSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = player.transform.position + new Vector3(0, 1, -5);

        camX = Mathf.Clamp(player.transform.position.x, minX + camRatio, maxX - camRatio);
        camY = Mathf.Clamp(player.transform.position.y, minY + camOrthSize, maxY - camOrthSize);
        this.transform.position = new Vector3(camX, camY, mainCamera.transform.position.z);
    }

}
