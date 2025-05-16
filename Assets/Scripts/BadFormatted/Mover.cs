using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _waypoints;

    private Transform[] _arrayPlaces;

    private int _waypointIndex;

    private void Start()
    {
        _arrayPlaces = new Transform[_waypoints.childCount];

        for (int index = 0; index < _waypoints.childCount; index++)
            _arrayPlaces[index] = _waypoints.GetChild(index).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform _waypoint = _arrayPlaces[_waypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, _speed * Time.deltaTime);

        if (transform.position == _waypoint.position) 
            GetNextPosition();
    }
    private Vector3 GetNextPosition()
    {
        _waypointIndex++;

        if (_waypointIndex == _arrayPlaces.Length)
            _waypointIndex = 0;

        Vector3 waypointPosition = _arrayPlaces[_waypointIndex].transform.position;

        transform.forward = waypointPosition - transform.position;

        return waypointPosition;
    }
}