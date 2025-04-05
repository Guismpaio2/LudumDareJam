using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour{
    [SerializeField] private string levelName1;
    [SerializeField] private string levelName2;
    [SerializeField] private string levelName3;
    [SerializeField] private string levelSelector;
    [SerializeField] private string finalScreen;

    public void ChangeScene(){
        if(PlayerPrefs.GetInt(levelName1) == 1 && PlayerPrefs.GetInt(levelName2) == 1 && PlayerPrefs.GetInt(levelName3) == 1)
        {
           SceneManager.LoadScene(finalScreen);
        }
        else
            SceneManager.LoadScene(levelSelector);
    }
}