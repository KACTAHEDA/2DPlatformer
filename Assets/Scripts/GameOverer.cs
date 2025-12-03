using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private Player _player;
    private bool _isGameOver = false;

    private void Awake()
    {
        _gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        ReloadScene();
    }

    private void OnEnable()
    {
        EventBus.IsDead += DisplayGameOverText;
    }

    private void OnDisable()
    {
        EventBus.IsDead -= DisplayGameOverText;
    }

    private void DisplayGameOverText()
    {
        _isGameOver = true;
        _gameOverText.gameObject.SetActive(true);
    }

    private void ReloadScene()
    {
        if(_isGameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
