using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public TMP_InputField inputText;
    public GameObject warning;
    public TextMeshProUGUI bestScore;

    void Start(){
        GameManager.Instance.LoadFile();
        if(!string.IsNullOrEmpty(GameManager.Instance.playerName)){
            bestScore.text = $"Best Score : {GameManager.Instance.playerName} : {GameManager.Instance.highestScore}";
        }
        if(!string.IsNullOrEmpty(GameManager.Instance.inputNameText)){
            inputText.text = GameManager.Instance.inputNameText;
        }
    }


    public void StartGame(){

        if(!string.IsNullOrEmpty(inputText.text)){
            Debug.Log(inputText.text);
            GameManager.Instance.inputNameText = inputText.text;
            warning.SetActive(false);
            SceneManager.LoadScene(1);
        }
        else{
            warning.SetActive(true);
        }
        
    }

    public void ExitGame(){
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
