using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance)
            target = PlayerController.instance.transform;
        else
            Debug.Log("player instance has not yet been created.");
    }

    // LateUpdate is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    public void setTarget(Transform t)
    {
        target = t;
    }
}
