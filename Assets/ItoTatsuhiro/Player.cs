using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet = null;       //ÉvÉåÉCÉÑÅ[ÇÃî≠éÀÇ∑ÇÈíe

    Rigidbody2D _rigidbody = null;

    [SerializeField]
    private float _movespeed_x = 1f;

    [SerializeField]
    private float _jumppower = 300f;



    //[SerializeField]
    //private float v = 1;

    //private Vector2 move = new Vector2(h, v);

    private void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>();    //
    }


    void move()
    {
        float x = Input.GetAxis("Horizontal");      //â°ÇÃà⁄ìÆ

        Vector2 move = new Vector2(x * _movespeed_x, _rigidbody.velocity.y);
        //_rigidbody.AddForce(move);
        _rigidbody.velocity = move;



        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jump = new Vector2(0, _jumppower);
            _rigidbody.AddForce(jump, ForceMode2D.Impulse);
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
