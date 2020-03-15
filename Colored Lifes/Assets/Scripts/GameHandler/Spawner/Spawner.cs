using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject basiquePlayer;
    [SerializeField]
    private GameObject doubleJumpPlayer;

    [SerializeField]
    private bool spawnFacingLeft;

    private GameObject currentPlayer;

    private Transform _transform;
    // Awake is called before all start functions
    private void Awake()
    {
        // Spawner awake
        Debug.Log("Spawner awake");
        _transform = GetComponent<Transform>();

        spawnPlayer("none");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //The player spawn
    public void spawnPlayer(string powerup)
    {
        //Apply the powerup
        switch(powerup)
        {
            case "none":
                currentPlayer = Instantiate(basiquePlayer, _transform.position, _transform.rotation);
                break;
            case "doublejump":
                currentPlayer = Instantiate(doubleJumpPlayer, _transform.position, _transform.rotation);
                break;
            default:
                currentPlayer = Instantiate(basiquePlayer, _transform.position, _transform.rotation);
                break;
        }
        
        currentPlayer.GetComponent<PlayerScript>().setSpawner(this);


        if(spawnFacingLeft)
        {
            currentPlayer.GetComponent<PlayerMovementScript>().Flip();
        }
    }
}
