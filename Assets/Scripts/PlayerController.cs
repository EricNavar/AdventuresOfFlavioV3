using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Animator myAnim;
    public static PlayerController instance;
    //name of the entance/exit pair
    public string areaTransitionName;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //This sets the target of the main camera to this.transform.
        //This is only necessary if the game is started in a scene without the player.
        GameObject.Find("Main Camera").GetComponent<CameraController>().setTarget(transform);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        theRB.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        if (inputX == -1 || inputX == 1 || inputY == -1 || inputY == 1)
        {
            myAnim.SetFloat("lastMoveX", inputX);
            myAnim.SetFloat("lastMoveY", inputY);
        }
    }
}
