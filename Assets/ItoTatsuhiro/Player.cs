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
    private float _movespeed_x = 1.0f;

    [SerializeField]
    private float _jumppower = 300f;

    [SerializeField]
    private float _bullet_interval = 1.0f;

    private float _bullet_interval_count = 0;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();    //
    }


    void move()
    {
        float x = Input.GetAxis("Horizontal");      //â°ÇÃà⁄ìÆ

        Vector2 move = new Vector2(x * _movespeed_x, _rigidbody.velocity.y);
 
        _rigidbody.velocity = move;



        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jump = new Vector2(0, _jumppower);
            _rigidbody.AddForce(jump, ForceMode2D.Impulse);
        }
    }

    void Bullet()
    {
        if (Input.GetMouseButton(0) && _bullet_interval_count <= 0)
        {

            Instantiate(bullet, new Vector3(transform.position.x + 2.0f, transform.position.y, transform.position.z), transform.rotation);

            _bullet_interval_count = _bullet_interval;
        }

        if (_bullet_interval_count != 0)
        {
            _bullet_interval_count -= Time.deltaTime;
        }

    }



    void Update()
    {
        move();
        Bullet();
    }
}
