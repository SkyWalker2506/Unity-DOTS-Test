using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct MovementSystem : ISystem
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
        foreach (RefRO<SpawnerData> spawner in SystemAPI.Query<RefRO<SpawnerData>>())
        {
            ProcessMovement(ref state, spawner);
        }
        initialized = true;
    }
    
    private void ProcessMovement(ref SystemState state, RefRO<SpawnerData> spawner)
    {
        for (int i = 0; i < spawner.ValueRO.MaxSpawnCount; i++)
        {
            float3 pos = Random.NextFloat3(new float3(-50, 0, -50), new float3(50, 0, 50));
            //state.EntityManager.SetComponentData(entity, LocalTransform.FromPosition(pos));
        }
    }
    
}