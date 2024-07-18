using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;
    int stop = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10;
            stop = 0;
        }

        transform.Rotate(0, 0, this.rotSpeed);

        this.rotSpeed *= 0.96f;


        /*
        if (Input.GetMouseButtonDown(1))
        {
            stop = 1;
        }
        if (stop == 1)
        {
            if (this.rotSpeed >= 0)
            {
                this.rotSpeed -= 0.2f;

            }
            
        }

        if (rotSpeed < 0)
        {
            this.rotSpeed=0;
        }
        */
    }
}
