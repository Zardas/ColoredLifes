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

    [SerializeField]
    public GameObject outline;

    [SerializeField]
    public GameObject corpse;

    public Spawner spawner;

    public string nextPower;

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
        nextPower = "none";
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInputScript.isXPressed)
        {
            //Make the player die
            PlayerDie();
        }
    }


    private void PlayerDie()
    {
        //Leave corpse
        Instantiate(corpse, transform.position, transform.rotation);

        //Spawn new player
        spawner.spawnPlayer(nextPower);

        //Kill current player
        Destroy(this.gameObject);
    }

    public void setSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }
}
