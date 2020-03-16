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

    private Transform _transform;

    private bool isPushed;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Test overlapBox");
        isPushed = false;

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(_transform.position, _transform.localScale, 0f);

        int i = 1;
        foreach(Collider2D col in hitColliders)
        {
            //On vérifie que c'est un truc lourd
            Debug.Log(i + " : " + col.gameObject.name);

            Characteristics car = col.gameObject.GetComponent<Characteristics>();

            if(car != null)
            {
                isPushed = car.isHeavy;
            }
        }

        Debug.Log("Is pushed ? " + isPushed);

        associatedDoor.setDoor(isPushed);
    }


    //On active le bouton
    /*private void OnTriggerEnter2D(Collider2D collision)
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
    }*/


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
