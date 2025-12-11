using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelCompleteText;

    private bool _isPased = false;

    private void Update()
    {
        TryLoadScene();
    }

    private void TryLoadScene()
    {
        if (_isPased && Input.anyKeyDown)
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
