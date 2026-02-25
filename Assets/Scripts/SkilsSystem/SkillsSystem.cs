using System.Collections.Generic;
using UnityEngine;

public class SkillsSystem : MonoBehaviour
{
    [SerializeField] private List<SkillSlot> _skillSlots;

    public void UseSkillOne() => ActivateSlot(0);

    private void ActivateSlot(int index)
    {
        if (index < 0 || index >= _skillSlots.Count)
            return;
        
        _skillSlots[index].Activate();
    }
}
