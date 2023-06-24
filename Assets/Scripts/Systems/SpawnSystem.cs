using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct SpawnSystem : ISystem
{
    private bool initialized;
    private Random Random;

    public void OnUpdate(ref SystemState state)
    {
        if (initialized)
        {
            return;
        }
        Random = new Random(1);
        foreach (RefRW<SpawnerData> spawner in SystemAPI.Query<RefRW<SpawnerData>>())
        {
            ProcessSpawner(ref state, spawner);
        }
        initialized = true;
    }
    
    private void ProcessSpawner(ref SystemState state, RefRW<SpawnerData> spawner)
    {
        for (int i = 0; i < spawner.ValueRO.SpawnCount; i++)
        {
            Entity entity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
            float3 pos = Random.NextFloat3(new float3(-30, 0, -50), new float3(30, 0, 50));
            state.EntityManager.SetComponentData(entity, LocalTransform.FromPosition(pos));
        }
    }
    
}