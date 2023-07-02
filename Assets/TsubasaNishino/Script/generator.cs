using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    [SerializeField] GameObject _bulletprefab = default;
    [SerializeField] float _interval = 1f;
    [SerializeField] bool _generatorOnstart = true;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        if (_generatorOnstart)
        {
            _timer = _interval;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _interval)
        {
            _timer = 0;
            var trashPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(_bulletprefab, trashPos, Quaternion.identity);
        }
    }
}
