using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPathing : MonoBehaviour
{
    #region
    // переменная для объекта с данными
    private WaveConfig _waveConfig;
    // скорость передвижения префаба
    private float _moveSpeed;
    #endregion

    // список точек перемещения в виде позиций Vector3
    private List<Transform> _waypoints;
    // индекс точки
    private int _waypointIndex = 0;
    void Start()
    {
        _waypoints = _waveConfig.GetWaypoints();
        _moveSpeed = _waveConfig.GetMoveSpeed();
        transform.position = _waypoints[_waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        _waveConfig = waveConfig;
    }

    private void Move()
    {
        if (_waypointIndex <= _waypoints.Count - 1)
        {
            // следующая точка
            var targetPosition = _waypoints[_waypointIndex].transform.position;
            // скорость перемещения приведённая
            var movementThisFrame = _moveSpeed * Time.deltaTime;
            // движение от... и до...
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
