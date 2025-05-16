using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly Transform _waypoint;

    private Transform[] _waypoints;

    private int _waypointIndex;

    private float _closeDistance = 0.01f;

    private void Awake()
    {
        InitWaypoints();
    }

    private void Start()
    {
        ToFirstPoint();
    }

    private void Update()
    {
        Transform waypoint = _waypoints[_waypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        Vector3 distanceToWaypoint = waypoint.position - transform.position;

        if (distanceToWaypoint.sqrMagnitude < (_closeDistance * _closeDistance))
            SetNextPosition();
    }

    private void InitWaypoints()
    {
        _waypoints = new Transform[_waypoint.childCount];

        for (int index = 0; index < _waypoint.childCount; index++)
            _waypoints[index] = _waypoint.GetChild(index);
    }

    private void ToFirstPoint()
    {
        if (_waypoints.Length > 0)
            transform.forward = _waypoints[0].position - transform.position;
    }

    private void SetNextPosition()
    {
        _waypointIndex = (_waypointIndex + 1) % _waypoints.Length;

        transform.forward = _waypoints[_waypointIndex].position - transform.position;
    }
}
