using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private SpriteRenderer _flip;
    private int _currentPoint = 0;
    private Vector3 _target;

    private void OnEnable()
    {
        _flip = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _target = _points[_currentPoint].position;

        if (_currentPoint % _points.Length == 0)
        {
            _flip.flipX = false;
        }
        else
        {
            _flip.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
        {
            _currentPoint++;

            if (_currentPoint > _points.Length - 1)
            {
                _currentPoint = 0;
            }
        }
    }

}
