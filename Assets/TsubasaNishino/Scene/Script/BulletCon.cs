using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCon : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject ,3f);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Vector2.left * _moveSpeed;
    }
}
