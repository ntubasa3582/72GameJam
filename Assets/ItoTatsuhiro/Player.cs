using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet = null;       //プレイヤーの発射する弾

    Rigidbody2D _rigidbody = null;

    [SerializeField]
    private float _movespeed_x = 1.0f;

    [SerializeField]
    private float _jumppower = 300f;

    [SerializeField]
    private float _bullet_interval = 1.0f;

    private float _bullet_interval_count = 0;

    [SerializeField]
    private float _jump_max = 1;        //ジャンプ回数

    private float _jump_count = 0;      //ジャンプ回数のカウント


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();    //
    }


    void move()
    {
        float x = Input.GetAxis("Horizontal");      //横の移動

        Vector2 move = new Vector2(x * _movespeed_x, _rigidbody.velocity.y);
 
        _rigidbody.velocity = move;

            if (Input.GetButtonDown("Jump") && _jump_count < _jump_max)
            {
                _jump_count++;

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

        if (_bullet_interval_count > 0)
        {
            _bullet_interval_count -= Time.deltaTime;
        }

    }



    void Update()
    {
        move();
        Bullet();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grond"))
        {
            _jump_count = 0;
        }
    }


}
