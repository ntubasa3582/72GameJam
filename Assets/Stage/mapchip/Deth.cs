using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deth : MonoBehaviour
{
    bool _swich = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DethLine" || collision.gameObject.tag == "Enemy")
        {
            if (_swich == false)
            {
                transform.position = new Vector2(-2.914873f, -0.4052666f);
            }
            if(_swich == true)
            {
                transform.position = new Vector2(43f,4f);
            }

        }
        if (collision.gameObject.tag == "tyukan")
        {
            _swich = true;
            Destroy(collision.gameObject);
        }
    }
}
