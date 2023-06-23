using Unity.Entities;
using Unity.Mathematics;

public struct MovementData : IComponentData
{
    public float3 Direction;
    public float3 Speed;
    public float3 MinPos;
    public float3 MaxPos;
}