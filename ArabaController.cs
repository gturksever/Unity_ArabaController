using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum  Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;

}
public class ArabaController : MonoBehaviour
{
    [SerializeField]
    private float MaksimumHizlanma = 200f;
    [SerializeField]
    private float donusHassasiyeti = 1f;
    [SerializeField]
    private float MaksimumDonusAcisi = 45f;
    [SerializeField]
    private List<Wheel> wheels;
    

    private float inputX, inputY;


    private void Start()
    {
        
    }

    private void Update()
    {
        
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }


    private void LateUpdate()
    {
        Move();
        Turn();

    }

    private void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * MaksimumHizlanma * 500 * Time.deltaTime;
        }
    }

    private void Turn() 
    {
        foreach (var wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * donusHassasiyeti * MaksimumDonusAcisi;

                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle,_steerAngle,0.1f);

            }
            
            
            
            
            
        }
    }

   

}



