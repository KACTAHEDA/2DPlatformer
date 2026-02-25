using UnityEngine;

public class SkillVisualRadius : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnEnable()
    {
        _skill.Activated += Activate;
        _skill.Deactivated += Deactivate;
    }

    private void OnDisable()
    {
        _skill.Activated -= Activate;
        _skill.Deactivated -= Deactivate;
    }

    public void Activate()
    {
        _renderer.enabled = true;
    } 
    
    public void Deactivate()
    {
        _renderer.enabled = false;
    }
}
