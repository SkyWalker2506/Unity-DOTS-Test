using System;
using TMPro;
using Unity.Entities;
using UnityEngine;

public class EntityCounter : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private void Awake()
    {
        UpdateText(0);
    }

    private void OnEnable()
    {
        if (World.DefaultGameObjectInjectionWorld != null)
        {
            EntityCounterSystem entityCounterSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<EntityCounterSystem>();
            entityCounterSystem.OnEntityCountChanged += UpdateText;
        }

    }

    private void OnDestroy()
    {
        if (World.DefaultGameObjectInjectionWorld != null)
        {
            EntityCounterSystem entityCounterSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<EntityCounterSystem>();
            entityCounterSystem.OnEntityCountChanged -= UpdateText;
        }

    }

    private void UpdateText(int value)
    {
        _text.SetText(value.ToString());
    }
}