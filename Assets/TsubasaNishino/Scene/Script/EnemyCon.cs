using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyCon : MonoBehaviour
{
    [SerializeField] int _w;
    [SerializeField] int _h;
    [SerializeField] int _radiusX;
    [SerializeField] int _radiusY;
    Rigidbody2D _rb;
    Vector2 _basePosition;
    Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _basePosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Cos(Time.time * _w);
        float y = Mathf.Sin(Time.time * _h);
        transform.position = new Vector2(_basePosition.x + x * _radiusX, _basePosition.y + y * _radiusY);   
    }

   
}
