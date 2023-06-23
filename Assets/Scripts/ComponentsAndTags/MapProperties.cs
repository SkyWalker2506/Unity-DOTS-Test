using Unity.Entities;
using Unity.Mathematics;

public struct MapProperties : IComponentData
{
    public float2 FieldDimensions;
    public int MaxSoldierCount;
    public Entity Soldier;
}