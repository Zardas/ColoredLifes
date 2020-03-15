using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{

    [SerializeField]
    internal PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        print("Player collision script starting");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.CompareTag("DoesDamage"))
        {
            //Damage taken
        }*/
        if(collision.gameObject.name == "Powerup_doubleJump")
        {
            Destroy(collision.gameObject);

            playerScript.nextPower = "doublejump";
            playerScript.outline.GetComponent<SpriteRenderer>().color = new Color(185f/255, 104f/255, 25f/255, 1f);
            playerScript.outline.GetComponent<SpriteRenderer>().enabled = true;
            
            Debug.Log("Double jump");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
