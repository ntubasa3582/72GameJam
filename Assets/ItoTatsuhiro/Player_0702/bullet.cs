//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletspeed;

    private float _bullettime;      //��������Ă���̎���

    [SerializeField]
    private float _bullettime_destroy = 2.0f;      //������܂ł̎���

    private Rigidbody2D _rigidbody;

    Player _player;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        GameObject obj = GameObject.Find("Unitychan");
        _player = obj.GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void DeleteBullet()
    {
        if (_bullettime >= _bullettime_destroy)
        {
            Destroy(gameObject);    //��ʊO�ɏo���e������
            _bullettime = 0;
        }
    }
    float _dir = 1f;
    public void SetDir(float dir)
    {
        _dir = dir;
    }
    void Update()
    {
        _rigidbody.velocity = Vector2.right * _bulletspeed * _dir;

        DeleteBullet();

        _bullettime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
