using System;
using System.Linq;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

public partial class EntityCounterSystem : SystemBase
{
    public int CurrentCount;
    public Action<int> OnEntityCountChanged;
    public EntityQuery _entityQuery; 
    public EntityManager _entityManager;
    private NativeArray<Entity> _entities;

    protected override void OnStartRunning()
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager; 
        _entityQuery = _entityManager.CreateEntityQuery(typeof(EntityParentTag));
    }

    protected override void OnUpdate()
    {
        UpdateCount();
    }
    
    private void UpdateCount()
    {
        _entities= _entityQuery.ToEntityArray(Allocator.TempJob);
        if (CurrentCount != _entities.Length)
        {
            CurrentCount = _entities.Length;
            OnEntityCountChanged?.Invoke(CurrentCount);
        }
    }
}