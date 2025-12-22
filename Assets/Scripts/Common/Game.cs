using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Finisher _finisher;

    private void OnEnable()
    {
        _collisionHandler.OnDoor += EndLevel;
    }

    private void OnDisable()
    {
        _collisionHandler.OnDoor -= EndLevel;
    }

    private void EndLevel()
    {
        _finisher.LevelPased();
    }
}
