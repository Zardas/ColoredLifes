using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        pushCheck();
    }


    //Test si la boite est poussée par un objet pouvant pousser les objets lourds
    private void pushCheck()
    {
        freezeXaxis();

        RaycastHit2D hitRight = Physics2D.Raycast(_transform.position, new Vector2(1, 0), 1);
        RaycastHit2D hitLeft = Physics2D.Raycast(_transform.position, new Vector2(-1, 0), 1);

        if (hitRight.collider != null)
        {
            Characteristics car = hitRight.collider.gameObject.GetComponent<Characteristics>();
            if (car != null)
            {
                //Si l'objet à droite peut pousser les objets lourds
                if (car.canPushHeavyObject)
                {
                    unfreezeXaxis();
                }
            }
        }

        if (hitLeft.collider != null)
        {
            Characteristics car = hitLeft.collider.gameObject.GetComponent<Characteristics>();
            if (car != null)
            {
                //Si l'objet à droite peut pousser les objets lourds
                if (car.canPushHeavyObject)
                {
                    unfreezeXaxis();
                }
            }
        }
    }


    private void freezeXaxis()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    private void unfreezeXaxis()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawRay(new Ray(_transform.position, new Vector2(1, 0)));
        Gizmos.DrawRay(new Ray(_transform.position, new Vector2(-1, 0)));
    }*/
}
