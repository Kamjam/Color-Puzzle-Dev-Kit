using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    
    [Tooltip("The player's movement speed")]
    [SerializeField] private float moveSpeed = 5f;

    [Tooltip("Object the player follows.")]
    public Transform movePointer;

    [Tooltip("Handles all collision on the collider mask")]
    public LayerMask colliderMask;

    [Tooltip("Player animator")]
    public Animator anim;

    void Start()
    {
        //transform is no longer a child of the player
        movePointer.parent = null;
    }

    void Update()
    {
        Vector3 horzMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        Vector3 vertMovement = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

        //player moves towards the move point   
        transform.position = Vector3.MoveTowards(transform.position, movePointer.position, moveSpeed * Time.deltaTime);

        //makes sure the player is near the move point in order to move
        if(Vector3.Distance(transform.position, movePointer.position) <= .05f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //checks if the player is colliding with layer mask before allowing the movement, else get pushed back
                if(!Physics2D.OverlapCircle(movePointer.position + horzMovement, .25f, colliderMask))
                {    
                    movePointer.position += horzMovement;
                }
                else
                    movePointer.position -= horzMovement;
            }
            //else if, to prevent diagonal movement
            else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePointer.position + vertMovement, .25f, colliderMask))
                {
                    movePointer.position += vertMovement;
                }
                else
                    movePointer.position -= vertMovement;
            }

            //uncomment back to add proper movement animation
            //anim.SetBool("moving", false);
        }

        //uncomment back to add proper movement animation
        /*else
            anim.SetBool("moving", true);*/
    }
}