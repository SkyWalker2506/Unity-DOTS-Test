using Unity.Entities;

public struct SpawnerData : IComponentData
{
    public Entity Prefab;
    public int MaxSpawnCount;
}