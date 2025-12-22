using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Finisher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelCompleteText;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CollisionHandler _collisionHandler;

    private bool _isPased = false;

    private void OnEnable()
    {
        _collisionHandler.OnDoor += LevelPased;
        _playerInput.KeyPressed += TryLoadScene;
    }

    private void OnDisable()
    {
        _collisionHandler.OnDoor -= LevelPased;
        _playerInput.KeyPressed -= TryLoadScene;
    }

    private void TryLoadScene()
    {
        if (_isPased)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _isPased = false;
        }
    }

    public void LevelPased()
    {
        _isPased = true;
        Time.timeScale = 0;
        _levelCompleteText.gameObject.SetActive(true);
    }
}
