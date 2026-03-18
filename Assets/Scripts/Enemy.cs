using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _groundHeight = -2;
    private Target _target;

    public event Action<Enemy> Fell;

    private void Update()
    {
        transform.LookAt(_target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        if(transform.position.y < _groundHeight)
            Fell?.Invoke(this);
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }
}