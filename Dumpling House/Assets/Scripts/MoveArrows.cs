using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
{ 

    // PLAYER = ARROWS + SPACE FOR BOMBS

    public float Speed; // speed (public) 
    float MovementX; // x direction
    float MovementY; // y direction

    // animations
    Vector3 movement; 
    public Animator animator;

    Rigidbody2D Rb; // reference players rigid body

    //DumplingBombs
    [SerializeField]

    public GameObject dumpling;
    //public int obstacleCount;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>(); // reference to access player
        // starting position
        MovementX = 0;
        MovementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //// changing speed of character each frame
        //Rb.velocity = new Vector2(MovementX * Speed * Time.deltaTime, MovementY * Speed * Time.deltaTime);

        // a place to store input
        if (Input.GetKeyDown(KeyCode.UpArrow)) //up 
        {
            MovementY = 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) // down 
        {
            MovementY = -1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) //left 
        {
            MovementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) // right 
        {
            MovementX = 1;
        }

        // want the player to stop moving when up stop pressing the key
        if (Input.GetKeyUp(KeyCode.UpArrow) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            MovementY = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            MovementX = 0;
        }

        if (Input.GetKeyDown("space"))
        {
            DropBomb(); // drop bomb using space key
        }

        //animations
        animator.SetFloat("Horizontal", MovementX);
        animator.SetFloat("Vertical", MovementY);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // changing sped of character each frome 
        Rb.velocity = new Vector2(MovementX * Speed * Time.deltaTime, MovementY * Speed * Time.deltaTime);

        //transform.Translate(movement * Speed * Time.deltaTime);

    }

    void DropBomb()
    {
        //create bomb at player position
        Instantiate(dumpling, this.gameObject.transform.position, Quaternion.identity);
    }
}