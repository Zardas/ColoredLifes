using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{

    [SerializeField]
    internal PlayerScript playerScript;


    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;

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

        //Up pressed
        isUpPressed = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow);

        //Down pressed
        isDownPressed = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
    }
}
