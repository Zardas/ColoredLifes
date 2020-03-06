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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
