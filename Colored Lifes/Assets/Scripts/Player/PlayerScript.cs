using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    internal PlayerInputScript playerInputScript;
    [SerializeField]
    internal PlayerMovementScript playerMovementScript;
    [SerializeField]
    internal PlayerCollisionScript playerCollisionScript;

    internal Rigidbody2D rigidBody;
    internal BoxCollider2D boxCollider2D;

    //Awake is called before all the Start functions
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        print("PlayerScript starting");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
