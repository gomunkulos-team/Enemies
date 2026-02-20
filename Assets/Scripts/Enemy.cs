using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _groundHeight = -2;

    public event Action<Enemy> Fell;

    private void Update()
    {
        if(transform.position.y < _groundHeight)
            Fell?.Invoke(this);
    }
}
