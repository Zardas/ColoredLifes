using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField]
    internal PlayerScript playerScript;


    [SerializeField] private float runSpeed = 400f;                              // Amount of force added when the player move
    [SerializeField] private float jumpForce = 8f;                            // Amount of force added when the player jumps
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded

    internal bool isGrounded;            // Whether or not the player is grounded.
    internal bool isJumping;            // Whether or not the player is jumping
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;

    [SerializeField]
    private float jumpsMax = 1;
    private float jumpsAvailable = 0;

    // Start is called before the first frame update
    void Start()
    {
        print("Player movement script starting");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Number of jumps available : " + jumpsAvailable);
        //Checking if the player is grounded
        checkGround();
        Jump();
    }

 
    //Fixed update is used when physic is involved
    void FixedUpdate()
    {

        //The ground check is done in PlayerCollisionScript
        //checkGround();
        MoveHorizontal(playerScript.playerInputScript.horizontalMove * runSpeed * Time.fixedDeltaTime);
    }


    private void Jump()
    {
        if (jumpsAvailable > 0 && playerScript.playerInputScript.isUpPressed_down)
        {
            // Make the character jump
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerScript.rigidBody.velocity = Vector2.up * jumpForce;
            jumpsAvailable--;
        }

        //Le joueur augmente la taille de son saut s'il continue d'appuyer sur jump
        if(playerScript.playerInputScript.isUpPressed && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                playerScript.rigidBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        //Dès que le joueur arrête d'appuyer sur space, son saut d'arrête
        if(playerScript.playerInputScript.isUpPressed_up)
        {
            isJumping = false;
        }
        
    }

    private void MoveHorizontal(float move)
    {

        //only control the player if grounded or airControl is turned on
        if (jumpsAvailable > 0 || m_AirControl)
        {

            // Move the character
            playerScript.rigidBody.velocity = new Vector2(move, playerScript.rigidBody.velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
    }


    private void checkGround()
    {
        isGrounded = false;

        BoxCollider2D boxCollider = playerScript.boxCollider2D;
        float extraHeight = .1f;

        RaycastHit2D[] raycastHits = Physics2D.BoxCastAll(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight);
        //RaycastHit2D[] raycastHits = Physics2D.RaycastAll(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extraHeight);

        Color rayColor = Color.red;
        
        foreach(RaycastHit2D raycastResult in raycastHits)
        {
            if (raycastResult.collider != null && raycastResult.collider.tag == "Platform")
            {
                rayColor = Color.green;
                isGrounded = true;
                jumpsAvailable = jumpsMax;
            }
        }

        //Debug.DrawRay(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + extraHeight));
    }




    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
