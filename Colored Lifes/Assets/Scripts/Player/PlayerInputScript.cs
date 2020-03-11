using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{

    [SerializeField]
    internal PlayerScript playerScript;


    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed_down;
    internal bool isUpPressed_up;
    internal bool isUpPressed;
    internal bool isDownPressed;
    internal bool isXPressed;

    internal float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        print("Player input script starting");
    }

    // Update is called once per frame
    void Update()
    {

        //-1 when pressing left ; 1 when pressing right ; 0 else
        horizontalMove = Input.GetAxisRaw("Horizontal");

        //Left pressed
        isLeftPressed = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow);

        //Right pressed
        isRightPressed = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        //Up pressed down
        isUpPressed_down = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space);
        //Up pressed (use for jump height control)
        isUpPressed_up = Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space);
        isUpPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space);

        //Down pressed
        isDownPressed = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        //X pressed
        isXPressed = Input.GetKeyDown(KeyCode.X);
    }
}
