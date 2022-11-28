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
    private SpawnPoint currentSpawnPoint = null;
    private int indexOfSpawnPoint = -1;
    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }
    public void MoveToLastSpawnPoint()
    {
        if(currentSpawnPoint != null)
        {
            transform.position = currentSpawnPoint.transform.position;
        }
        else
        {
            transform.position = startPos;
        }
    }

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
        if (anim)
        anim.SetFloat("Speed", Mathf.Abs(inputX));


        if (currentSpawnPoint == null)
        {
            SpawnPoint firstBigger = SpawnPoint.spawnPoints.Find(s => s.transform.position.x > transform.position.x);
            if (firstBigger != null)
            {
                int indexOfFirstBigger = SpawnPoint.spawnPoints.IndexOf(firstBigger);
                if (indexOfFirstBigger > 0)
                {
                    currentSpawnPoint = SpawnPoint.spawnPoints[indexOfFirstBigger - 1];
                    indexOfSpawnPoint = indexOfFirstBigger - 1;
                }
                
            }
        }
        else
        {
            if(indexOfSpawnPoint < SpawnPoint.spawnPoints.Count - 1)
            {
                if (transform.position.x >= SpawnPoint.spawnPoints[indexOfSpawnPoint + 1].transform.position.x)
                {
                    currentSpawnPoint = SpawnPoint.spawnPoints[indexOfSpawnPoint + 1];
                    indexOfSpawnPoint++;
                }
            }

        }

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

 


