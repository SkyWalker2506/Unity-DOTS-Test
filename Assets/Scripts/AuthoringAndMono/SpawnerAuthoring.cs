using Unity.Entities;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
}

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    private SpawnerData _spawnerData;
    public override void Bake(SpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        if (!authoring.Prefab.GetComponent<EntityParentTagAuthoring>())
        {
            authoring.Prefab.AddComponent<EntityParentTagAuthoring>();
        }

        _spawnerData = new SpawnerData
        {
            Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
            MaxSpawnCount = 2500000
        };
        
        AddComponent(entity, _spawnerData);
    }

}