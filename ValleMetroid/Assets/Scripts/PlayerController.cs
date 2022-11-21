using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed, jumpForce;

    public Transform groundPoint;
    public LayerMask whatIsGround;

    public bool isGrounded;

   // public Animator anim;

    private float inputX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the player
        //theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        theRB.velocity = new Vector2(inputX * moveSpeed, theRB.velocity.y);

        //check if on the ground
        isGrounded = Physics2D.OverlapCircle(transform.position, .55f, whatIsGround);

        


        // MÅSKE KAN DETTE BRUGE TIL ANIM
        /*anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

        if(theRB.velocity.x > 0f)
        {
            transform.localScale = Vector3.one;
        } else if(theRB.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }*/
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move " + context.phase);
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("JUMP " + context.phase);
        if ((isGrounded && context.phase == InputActionPhase.Started)) /* || (!isGrounded && context.phase == InputActionPhase.Canceled))*/
        {

            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    


    }
}


