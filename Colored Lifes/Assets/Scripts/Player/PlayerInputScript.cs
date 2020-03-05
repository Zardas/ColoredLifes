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
        isLeftPressed = Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow);

        //Right pressed
        isRightPressed = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        //Up pressed
        isUpPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow);

        //Down pressed
        isDownPressed = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    }
}
