using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] private Skill _skill;

    public void Activate()
    {
        _skill.TryActivate();
    }  
}
