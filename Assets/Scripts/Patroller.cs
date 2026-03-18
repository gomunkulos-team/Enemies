using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypoint = 0;
    private float _distanceTolerance = 1f;

    private void Update()
    {
        if ((transform.position - _waypoints[_currentWaypoint].position).magnitude < _distanceTolerance)
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}