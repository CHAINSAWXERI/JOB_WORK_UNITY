using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class MainJob : MonoBehaviour
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public float speed;
    [SerializeField] public int spawnCount;
    [SerializeField] public float radius;
    [SerializeField] private float interval;
    private float timer = 0f;

    private Transform[] _transforms;
    private TransformAccessArray _transformAccessArray;

    void Start()
    {
        _transforms = new Transform[spawnCount];
        for (int i = 0; i < spawnCount; i++)
        {
            Transform instanceTransform = Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;
            _transforms[i] = instanceTransform;
        }

        _transformAccessArray = new TransformAccessArray(_transforms);
    }

    private void Update()
    {
        HandleMovementJob();

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            LogJob();
        }
    }

    private void HandleMovementJob()
    {
        CyclicMovementJob movementJob = new CyclicMovementJob(speed, radius, Time.time);
        JobHandle jobHandle = movementJob.Schedule(_transformAccessArray);
        jobHandle.Complete();
    }

    private void LogJob()
    {
        int rnd = Random.Range(1, 101);
        Logar logarJob = new Logar(rnd);
        JobHandle jobHandle = logarJob.Schedule();
        jobHandle.Complete();
    }

    private void OnDestroy()
    {
        _transformAccessArray.Dispose();
    }
}
