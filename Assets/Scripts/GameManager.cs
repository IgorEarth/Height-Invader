using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [SerializeField] GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] CoinManager _coinManager;



    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR

        ShowAdv();

#endif
        _levelText.text = SceneManager.GetActiveScene().name;
    }
    public void Play()
    {
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();

#if UNITY_WEBGL && !UNITY_EDITOR
        Progress.Instance.Save();

#endif

    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }


    public void NextLevel()
    {

        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            _coinManager.SaveToProgress();

#if UNITY_WEBGL && !UNITY_EDITOR
            Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;
#endif

            SceneManager.LoadScene(next);
#if UNITY_WEBGL && !UNITY_EDITOR
            Progress.Instance.Save();
#endif
        }

    }
}
