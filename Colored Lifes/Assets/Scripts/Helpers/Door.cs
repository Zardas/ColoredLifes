using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool isOpen;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open()
    {
        isOpen = true;

        spriteRenderer.enabled = !isOpen;
        boxCollider.enabled = !isOpen;
    }
    public void close()
    {
        isOpen = false;

        spriteRenderer.enabled = !isOpen;
        boxCollider.enabled = !isOpen;
    }
}
