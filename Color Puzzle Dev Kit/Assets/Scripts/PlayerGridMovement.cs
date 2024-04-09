using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform movePointer;
    public LayerMask colliderMask;
    //public Animator anim;

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
                //checks if the player is colliding with layer mask before allowing the movement
                if(!Physics2D.OverlapCircle(movePointer.position + horzMovement, .2f, colliderMask))
                {    
                    movePointer.position += horzMovement;
                }
            }
            //else if, to prevent diagonal movement
            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePointer.position + horzMovement, .2f, colliderMask))
                {
                    movePointer.position += vertMovement;
                }
            }

            //anim.SetBool("moving", false);
        }
        /*else
            anim.SetBool("moving", true);*/
    }
}