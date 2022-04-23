using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPathing : MonoBehaviour
{
    #region

    [SerializeField] private WaveConfig _waveConfig;
    [SerializeField] private float moveSpeed;
    #endregion

    private List<Transform> _waypoints;
    private int _waypointIndex = 0;
    void Start()
    {
        _waypoints = _waveConfig.Waypoints();
        transform.position = _waypoints[_waypointIndex].transform.position;
        moveSpeed = _waveConfig.MoveSpeed;
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
