using Unity.Entities;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public int SpawnCount = 15000;
}

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        if (!authoring.Prefab.GetComponent<EntityParentTagAuthoring>())
        {
            authoring.Prefab.AddComponent<EntityParentTagAuthoring>();
        }
        AddComponent(entity,new SpawnerData
        {
            Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
            SpawnCount = authoring.SpawnCount
        });
    }
}