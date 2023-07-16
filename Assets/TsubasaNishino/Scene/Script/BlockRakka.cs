using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRakka : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rigidbody2.gravityScale = 1;
        }
    }
}
