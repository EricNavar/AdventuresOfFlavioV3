using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Tilemap tm;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance)
            target = PlayerController.instance.transform;
        else
            Debug.Log("player instance has not yet been created.");
        tm.CompressBounds();
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        Vector3 halfCameraSize = new Vector3(halfWidth, halfHeight, 0);
        bottomLeftLimit = tm.localBounds.min + halfCameraSize;
        topRightLimit = tm.localBounds.max - halfCameraSize;
    }

    // LateUpdate is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(target.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void setTarget(Transform t)
    {
        target = t;
    }
}
