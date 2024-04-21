using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public TMP_Text BestTimeMap1;
    public TMP_Text BestTimeMap2;
    public TMP_Text Coins;
    public GameObject Map2isBought;
    public GameObject Map2IsntBought;
    public GameObject CamaroIsntBought;
    public GameObject CamaroIsBought;
    private int CoinsNumbers=0;
    private float BTMap1=0;
    private float BTMap2=0;
    public bool Map2Bought=false;
    public bool CamaroBought=false;

    public void ChooseMap1(){
        SceneManager.LoadSceneAsync(1);
    }

    public void ChooseMap2(){
        SceneManager.LoadSceneAsync(2);
    }

    public void Quit(){
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        BTMap2=PlayerPrefs.GetFloat("BestTime2");
        BTMap1=PlayerPrefs.GetFloat("BestTime1");  
        CoinsNumbers=PlayerPrefs.GetInt("Coins");  
        if (PlayerPrefs.GetString("Mapa2Comprado") == "Comprado"){
            Map2Bought = true;
        }   
        if(PlayerPrefs.GetString("CamaroComprado")=="Comprado"){
            CamaroBought=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Coins.text= $"{CoinsNumbers}";
        BestTimeMap1.text = $"Melhor Tempo {Mathf.FloorToInt(BTMap1/60)}:{BTMap1 % 60:00.000}";
        BestTimeMap2.text = $"Melhor Tempo {Mathf.FloorToInt(BTMap2/60)}:{BTMap2 % 60:00.000}";

        if(Map2Bought){
            Map2isBought.SetActive(true);
            Map2IsntBought.SetActive(false);
        }
        if(Map2Bought){
            CamaroIsBought.SetActive(true);
            CamaroIsntBought.SetActive(false);
        }
    }

    public void BuyMap2(){
        if(CoinsNumbers>=110){
            CoinsNumbers = CoinsNumbers-110;
            PlayerPrefs.SetInt("Coins",CoinsNumbers);
            Map2Bought=true;
            PlayerPrefs.SetString("Mapa2Comprado","Comprado");
        }
        else Map2Bought = false;
    }

    public void BuyCamaro(){
        if(CoinsNumbers>=200){
            CoinsNumbers = CoinsNumbers-200;
            PlayerPrefs.SetInt("Coins",CoinsNumbers);
            CamaroBought=true;
            PlayerPrefs.SetString("CamaroComprado","Comprado");
        }
        else CamaroBought = false;
    }

    public void SelectCamaro(){
        PlayerPrefs.SetString("Carro","Camaro");
    }
    public void SelectCadette(){
        PlayerPrefs.SetString("Carro","Cadette");
    }
}
