using UnityEngine;
using TMPro;

public class CompleteLevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelCompleteText;
    [SerializeField ]private GameOverer _gameOverer;
    private bool _isComplete = false;

    private void Awake()
    {
        _levelCompleteText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_isComplete == true && Input.anyKeyDown)
        {
            _gameOverer.ExitGame();
        }
    }

    private void OnEnable()
    {
        EventBus.LevelComplete += CompleteLevel;
    }

    private void OnDisable()
    {
        EventBus.LevelComplete -= CompleteLevel;
    }

    private void CompleteLevel()
    {
        _isComplete = true;
        Time.timeScale = 0;
        _levelCompleteText.gameObject.SetActive(true);
    }
}
