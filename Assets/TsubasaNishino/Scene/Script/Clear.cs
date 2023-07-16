using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    [SerializeField] GameObject _buttonCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _buttonCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goalline")
        {
            _buttonCanvas.SetActive(true);
        }
    }
}
