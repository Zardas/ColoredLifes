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

        Characteristics car = collision.gameObject.GetComponent<Characteristics>();
        if(car != null)
        {

            //The player gathered a double jump power-up
            if(car.givePowerupWhenGathered == "doubleJump")
            {
                Destroy(collision.gameObject);

                playerScript.nextPower = "doublejump";
                playerScript.outline.GetComponent<SpriteRenderer>().color = new Color(185f / 255, 104f / 255, 25f / 255, 1f);
                playerScript.outline.GetComponent<SpriteRenderer>().enabled = true;

                Debug.Log("Double jump");
            }
            if (car.givePowerupWhenGathered == "heavy")
            {
                Destroy(collision.gameObject);

                playerScript.nextPower = "heavy";
                playerScript.outline.GetComponent<SpriteRenderer>().color = new Color(23f / 255, 45f / 255, 109f / 255, 1f);
                playerScript.outline.GetComponent<SpriteRenderer>().enabled = true;

                Debug.Log("Heavy");
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
