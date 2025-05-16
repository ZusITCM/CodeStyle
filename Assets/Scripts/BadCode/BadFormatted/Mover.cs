using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly Transform _waypoint;

    private Transform[] _waypoints;

    private int _waypointIndex;

    private void Start()
    {
        _waypoints = new Transform[_waypoint.childCount];

        for (int index = 0; index < _waypoint.childCount; index++)
            _waypoints[index] = _waypoint.GetChild(index).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform _waypoint = _waypoints[_waypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, _speed * Time.deltaTime);

        if (transform.position == _waypoint.position) 
            GetNextPosition();
    }

    private Vector3 GetNextPosition()
    {
        _waypointIndex++;

        if (_waypointIndex == _waypoints.Length)
            _waypointIndex = 0;

        Vector3 waypointPosition = _waypoints[_waypointIndex].transform.position;

        transform.forward = waypointPosition - transform.position;

        return waypointPosition;
    }
}