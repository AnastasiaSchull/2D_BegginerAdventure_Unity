using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button settingsBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button quitBtn;

    private void Awake()
    {
        resumeBtn.onClick.AddListener(() => Hide());
        restartBtn.onClick.AddListener(() => Restart());
    }
    void Update()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;//пауза
        isPaused = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);//видимо или невидимо меню
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
