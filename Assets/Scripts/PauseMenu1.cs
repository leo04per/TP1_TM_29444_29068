using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool isActive;

    public void Start(){
        PauseMenu.SetActive(false);
        isActive=false;
    }

    public void PauseGame(){
        PauseMenu.SetActive(true);
        isActive=true;
    }


    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isActive){
                Resume();
            }
            else {
                PauseGame();
            }
        }
    }

    public void Resume(){
        PauseMenu.SetActive(false);
        isActive=false;
    }

    public void GoToMain(){
        SceneManager.LoadSceneAsync(0);
    }
    public void Restart(){
        SceneManager.LoadSceneAsync(2);
    }

    public void Quit(){
        Application.Quit();
    }

}
