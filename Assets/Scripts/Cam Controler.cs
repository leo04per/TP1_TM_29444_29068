using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamControler : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 offset;

    private void Update(){
        transform.position = PlayerTransform.position + offset;
    }


}
