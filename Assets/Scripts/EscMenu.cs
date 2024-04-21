using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
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


    public void Home(){
        SceneManager.LoadSceneAsync(0);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Restart(){
        SceneManager.LoadSceneAsync(1);
    }

    public void Resume(){
        PauseMenu.SetActive(false);
        isActive=false;
    }


}
