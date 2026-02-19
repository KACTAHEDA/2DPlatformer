using System.Collections.Generic;
using UnityEngine;

public class SkillsSystem : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private List<SkillSlot> _skillSlots;

    private void OnEnable()
    {
        foreach (var skilSlot in _skillSlots)
        {
            skilSlot.Initialize();
        }

        _playerInput.SkillOnePressed += UseSkillOne;
    }

    private void OnDisable()
    {
        foreach (var skilSlot in _skillSlots)
        {
            skilSlot.Dispose();
        }

        _playerInput.SkillOnePressed -= UseSkillOne;
    }

    private void UseSkillOne() => ActivateSlot(0);

    private void ActivateSlot(int index)
    {
        if (index < 0 || index >= _skillSlots.Count)
            return;

        _skillSlots[index].Activate();
    }
}
