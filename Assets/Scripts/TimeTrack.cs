using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTrack : MonoBehaviour
{
    public bool StartTimer=false, CheckPoint1=false, CheckPoint2=false, CheckPoint3=false, CheckPoint4=false;
    public float LapTime=0;
    public float BestTime=0;
    public float TotalTime=0;
    public TMP_Text LapTime_Text;
    public TMP_Text BestTime_Text;
    public int LapCount;
    public TMP_Text LapCounter_Text;
    public int Moedas=0;


    void Start()
    {

        Moedas = PlayerPrefs.GetInt("Coins");
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map1")){
            BestTime = PlayerPrefs.GetFloat("BestTime1");
            }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map2")){
            BestTime = PlayerPrefs.GetFloat("BestTime2");    
        }
        LapCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartTimer){
            LapTime += Time.deltaTime; 
        }
        
        LapTime_Text.text = $"Tempo {Mathf.FloorToInt(LapTime/60)}:{LapTime % 60:00.000}";
        BestTime_Text.text = $"Melhor Volta {Mathf.FloorToInt(BestTime/60)}:{BestTime % 60:00.000}";
        LapCounter_Text.text = $"Voltas {LapCount}   Moedas Obtidas {Moedas}";

        PlayerPrefs.SetInt("Coins",Moedas);

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map1")){
            PlayerPrefs.SetFloat("BestTime1",BestTime);
            }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map2")){
            PlayerPrefs.SetFloat("BestTime2",BestTime);    
        }
    }

    void OnTriggerEnter(Collider collision){
 
        switch (collision.gameObject.name) {
            case "StartLine":
            if(StartTimer==false){
                StartTimer=true;
                CheckPoint1=false;
                CheckPoint2=false;
                CheckPoint3=false;
                CheckPoint4=false;
                LapCount=0;
            }
            if(CheckPoint1 && CheckPoint2 && CheckPoint3 && CheckPoint4){
                StartTimer=false;
                StartTimer=true;
                
                if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map1")){
                    if(LapTime<35){
                    Moedas += 10;}
                    else Moedas += 5;
                }
                if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map2")){
                    if(LapTime<37){
                    Moedas += 15;}
                    else Moedas += 7;
                }

                // incrementar moedas
                if(BestTime==0){
                    BestTime=LapTime;
                }
                else if(LapTime<BestTime){
                    BestTime=LapTime;
                }
                LapCount++;
                LapTime=0;
                }
                break;
            case "CheckPoint1":
                CheckPoint1=true;
                break;
            case "CheckPoint2":
                CheckPoint2=true;
                break;
            case "CheckPoint3":
                CheckPoint3=true;
                break;
            case "CheckPoint4":
                CheckPoint4=true;
                break;
        
    }
    }
}
