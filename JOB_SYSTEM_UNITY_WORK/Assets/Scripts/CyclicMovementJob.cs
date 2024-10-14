using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public struct CyclicMovementJob : IJobParallelForTransform
{
    private float _speed;
    private float _radius;
    private float _time;

    public CyclicMovementJob(float speed, float radius, float time)
    {
        _speed = speed;
        _radius = radius;
        _time = time;
    }

    public void Execute(int index, TransformAccess transform)
    {
        float angle = _time * _speed + index * Mathf.PI / 4;
        float x = Mathf.Cos(angle) * _radius;
        float z = Mathf.Sin(angle) * _radius;

        transform.position = new Vector3(x, transform.position.y, z);
    }
}
