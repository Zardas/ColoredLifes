using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField]
    private Door associatedDoor;

    [SerializeField]
    private GameObject unpushedButton;
    [SerializeField]
    private GameObject pushedButton;


    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //On active le bouton
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("On ouvre la porte");

        pushedButton.GetComponent<SpriteRenderer>().enabled = true;
        unpushedButton.GetComponent<SpriteRenderer>().enabled = false;

        associatedDoor.open();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("On ferme la porte");

        pushedButton.GetComponent<SpriteRenderer>().enabled = false;
        unpushedButton.GetComponent<SpriteRenderer>().enabled = true;

        associatedDoor.close();
    }

}
