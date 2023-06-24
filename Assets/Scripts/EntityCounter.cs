using TMPro;
using Unity.Entities;
using UnityEngine;

public class EntityCounter : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private void OnEnable()
    {
        EntityCounterSystem entityCounterSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<EntityCounterSystem>();
        entityCounterSystem.OnEntityCountChanged += UpdateText;
    }

    private void OnDestroy()
    {
        EntityCounterSystem entityCounterSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<EntityCounterSystem>();
        entityCounterSystem.OnEntityCountChanged -= UpdateText;
    }

    private void UpdateText(int value)
    {
        _text.SetText(value.ToString());
    }
}