using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryCannon : Cannon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRotating == true)
        {
            Rotate();
        }
    }



    public override void Rotate()
    {
        RotateToTarget(_targetAngle);
    }



}
