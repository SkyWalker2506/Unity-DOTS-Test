using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementAuthoring : MonoBehaviour
{
    public float3 Direction;
    public float3 Speed;
    public float3 MinPos;
    public float3 MaxPos;
}

public class MovementBaker : Baker<MovementAuthoring>
{
    public override void Bake(MovementAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity,new MovementData
        {
            Direction = authoring.Direction,
            Speed = authoring.Speed,
            MinPos = authoring.MinPos,
            MaxPos = authoring.MaxPos
        });
    }
}