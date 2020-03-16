using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField]
    internal PlayerScript playerScript;


    [SerializeField] private float runSpeed = 400f;                              // Amount of force added when the player move
    [SerializeField] private float jumpForce = 8f;                              // Amount of force added when the player jumps
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded

    internal bool isGrounded;            // Whether or not the player is grounded.
    internal bool isJumping;            // Whether or not the player is jumping
    public bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;

    [SerializeField]
    private float additionnalJumps = 1;
    private float additionnalJumpsAvailable = 0;

    [SerializeField]
    private float fallSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        print("Player movement script starting");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Number of additionnals jumps available : " + additionnalJumpsAvailable);
        //Checking if the player is grounded
        checkGround();
        Jump();
        //if the player is falling, we accelerate is fall
        smoothMovement();
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
        if ((additionnalJumpsAvailable > 0 || isGrounded) && playerScript.playerInputScript.isUpPressed_down)
        {
            // Make the character jump
            isJumping = true;
            jumpTimeCounter = jumpTime;
            if(!isGrounded)
            {
                additionnalJumpsAvailable--;
            }
            playerScript.rigidBody.velocity = Vector2.up * jumpForce;
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

    private void smoothMovement()
    {
        //If the player is falling
        if(playerScript.rigidBody.velocity.y < 0)
        {
            playerScript.rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallSpeed - 1) * Time.deltaTime; //The -1 is because the gravity already apply a 1 in unity
        } else if(playerScript.rigidBody.velocity.y > 0 && !playerScript.playerInputScript.isUpPressed)
        {
            playerScript.rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (jumpForce - 1) * Time.deltaTime;
        }
    }

    private void MoveHorizontal(float move)
    {

        //only control the player if grounded or airControl is turned on
        if (additionnalJumpsAvailable > 0 || m_AirControl)
        {

           //Little TP to deal with the blocking due to Tilemaping collisions
            littleHorizontalTP();

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
                additionnalJumpsAvailable = additionnalJumps;
            }
        }

        //Debug.DrawRay(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + extraHeight));
    }




    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }





    private void littleHorizontalTP()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerScript.transform.position, new Vector2(playerScript.playerInputScript.horizontalMove, 0), 1);
        //S'il y a un truc devant nous, on vérifie qu'il n'est pas lourd. S'il est lourd, on n'avance pas
        if(hit.collider != null)
        {
            Debug.Log("TP : " + hit.collider.gameObject.name);
            Characteristics car = hit.collider.gameObject.GetComponent<Characteristics>();
            if (car != null)
            {
                if(!car.isHeavy)
                {
                    Debug.Log("On se TP");
                    //Little TP to deal with the little block due to TileMap
                    playerScript.transform.position = new Vector3(playerScript.transform.position.x + playerScript.playerInputScript.horizontalMove * 0.01f, playerScript.transform.position.y, playerScript.transform.position.z);
                }
            }
        } else //S'il n'y a rien devant nous, on peu se TP de base
        {
            playerScript.transform.position = new Vector3(playerScript.transform.position.x + playerScript.playerInputScript.horizontalMove * 0.01f, playerScript.transform.position.y, playerScript.transform.position.z);
        }

       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawRay(new Ray(playerScript.transform.position, new Vector2(playerScript.playerInputScript.horizontalMove, 0)));
    }
}
