using Unity.Entities;
using Unity.Transforms;

public readonly partial struct MapAspect : IAspect
{
    public readonly Entity Entity;

    private readonly RefRO<LocalTransform> _transform;
    private LocalTransform Transform => _transform.ValueRO;
    
     private readonly RefRO<MapProperties> _mapProperties;
     private readonly RefRW<MapRandom> _mapRandom;

}