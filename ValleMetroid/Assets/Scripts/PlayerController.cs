using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public float jumpForce;
    public Transform groundPoint;
    public LayerMask whatIsGround;
    public bool isGrounded;
    bool facingLeft = true;
    private float inputX;
    public Animator anim;  

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(inputX * moveSpeed, theRB.velocity.y);

        //check if on the ground
        isGrounded = Physics2D.OverlapCircle(transform.position, .55f, whatIsGround);

        if(inputX > 0 && facingLeft)
        {
            Flip();
        }
        if(inputX < 0 && !facingLeft)
        {
            Flip();
        }

        //MOVEMENT ANIMATION 
        anim.SetFloat("Speed", Mathf.Abs(inputX));

    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {  
        if ((isGrounded && context.phase == InputActionPhase.Started)) /* || (!isGrounded && context.phase == InputActionPhase.Canceled))*/
        {

            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1f;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }

}

 


