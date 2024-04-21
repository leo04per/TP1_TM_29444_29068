using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickCar : MonoBehaviour
{
    public GameObject Camaro;
    public GameObject Cadette;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Carro")=="Camaro"){
            Camaro.SetActive(true);
            Cadette.SetActive(false);
        }
        if(PlayerPrefs.GetString("Carro")=="Cadette"){
            Camaro.SetActive(false);
            Cadette.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
