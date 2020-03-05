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
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.



    // Start is called before the first frame update
    void Start()
    {
        print("Player movement script starting");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fixed update is used when physic is involved
    private void FixedUpdate()
    {
        //The ground check is done in PlayerCollisionScript

        Move(playerScript.playerInputScript.horizontalMove * runSpeed * Time.fixedDeltaTime, playerScript.playerInputScript.isUpPressed);
    }




    private void Move(float move, bool jump)
    {

        //only control the player if grounded or airControl is turned on
        if (isGrounded || m_AirControl)
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
        // If the player should jump
        if (isGrounded && jump)
        {
            // Make the character jump
            playerScript.rigidBody.velocity = new Vector2(move, jumpForce);
        }
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
