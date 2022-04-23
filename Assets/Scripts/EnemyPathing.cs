using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPathing : MonoBehaviour
{
    #region
    [SerializeField] private Transform path;
    [SerializeField] private float moveSpeed = 2f;
    #endregion

    private List<Transform> _waypoints;
    private int _waypointIndex = 1;
    void Start()
    {
        _waypoints = path.GetComponentsInChildren<Transform>().ToList();
        transform.position = _waypoints[_waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_waypointIndex <= _waypoints.Count - 1)
        {
            var targetPosition = _waypoints[_waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                movementThisFrame);
            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
