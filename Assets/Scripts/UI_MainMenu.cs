using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{

    [SerializeField] Button newGameBtn;
    [SerializeField] Button quitGameBtn;


    private void Awake()
    {
        newGameBtn.onClick.AddListener(() 
            => SceneManager.LoadScene("Sandbox"));

        quitGameBtn.onClick.AddListener(()
            => QuitGame());


    }


    private void QuitGame()
    {

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else

     Application.Quit();

#endif

    }


}
