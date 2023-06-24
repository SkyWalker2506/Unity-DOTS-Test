using Unity.Entities;
using UnityEngine;

public class EntityParentTagAuthoring : MonoBehaviour
{
}
public class EntityParentTagBaker : Baker<EntityParentTagAuthoring>
{
    public override void Bake(EntityParentTagAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity,new EntityParentTag());
    }
}