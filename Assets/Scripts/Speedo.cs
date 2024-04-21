using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedo : MonoBehaviour
{
    public TMP_Text Speed_Text;
    public Rigidbody Car_rigidBody;
    public RectTransform arrow;
    
    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;
    public float maxSpeed = 0.0f;   // max velocidade no speedometer
    private float speed = 0.0f;     // velocidade atual


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Car_rigidBody.velocity.magnitude * 3.6f;
        Speed_Text.text = (speed).ToString("0") + (" KM/H");
        arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}
