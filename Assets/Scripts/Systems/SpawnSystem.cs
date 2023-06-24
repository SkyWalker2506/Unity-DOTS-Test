using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

[BurstCompile]
public partial struct SpawnSystem : ISystem
{
    private Random Random;
    private int _counter;
    private static int _batchCount;
    private static bool _doSpawn;
    public void OnCreate(ref SystemState state)
    {
        Random = new Random(1);
        SpawnerUI.OnBatchChanged += SetBatchCount;
        SpawnerUI.OnSpawn += OnSpawn;
    }

    public void OnDestroy(ref SystemState state)
    {
        SpawnerUI.OnBatchChanged -= SetBatchCount;
        SpawnerUI.OnSpawn -= OnSpawn;
    }

    private void SetBatchCount(int value)
    {
        _batchCount = value;
        Debug.Log(_batchCount);
    }

    public void OnUpdate(ref SystemState state)
    {

        foreach (RefRW<SpawnerData> spawnerData in SystemAPI.Query<RefRW<SpawnerData>>())
        {
            ProcessSpawner(ref state, spawnerData);
        }

    }

    private void OnSpawn()
    {
        _doSpawn = true;
    }
    
    private void ProcessSpawner(ref SystemState state, RefRW<SpawnerData> spawner)
    {
        if (!_doSpawn)
        {
            return;
        }

        for (int i = 0; i < _batchCount; i++)
        {
            CreateOneEntity(state, spawner);
        }
        _doSpawn = false;
    }

    private void CreateOneEntity(SystemState state, RefRW<SpawnerData> spawner)
    {
        if (_counter < spawner.ValueRO.MaxSpawnCount)
        {
            Entity entity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
            float3 pos = Random.NextFloat3(new float3(-30, 0, -50), new float3(30, 0, 50));
            state.EntityManager.SetComponentData(entity, LocalTransform.FromPosition(pos));
            _counter++;
        }
    }
}