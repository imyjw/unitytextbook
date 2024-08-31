using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject generator;
    float time = 40.0f;
    int point = 0;

    public void Restart()//내가 추가로 만들어본 부분
    {
        this.generator.GetComponent<ItemGenerator>().span = 1.0f;
        this.generator.GetComponent<ItemGenerator>().speed = -0.03f;
        this.generator.GetComponent<ItemGenerator>().ratio = 3;
        this.time = 40.0f;
        this.point = 0;

        GameObject[] deletee = GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] deleteee= GameObject.FindGameObjectsWithTag("Bomb");
        for(int i = 0; i < deletee.Length; i++)
        {
            Destroy(deletee[i]);
        }
        for (int i = 0; i < deleteee.Length; i++)
        {
            Destroy(deleteee[i]);
        }
    }//내가 추가로 만들어본 부분

    public void GetApple()
    {
        this.point += 100;
    }
    public void GetBomb()
    {
        this.point /= 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        this.time = time-Time.deltaTime;
        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0<=this.time&&this.time < 6)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.6f, -0.06f, 2);
        }
        else if (6 <= this.time && this.time < 16)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.4f, -0.06f, 6);
        }
        else if (16 <= this.time && this.time < 27)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 5);
        }
        else if (27 <= this.time && this.time < 33)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 4);
        }
        else if (33 <= this.time && this.time < 39)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.9f, -0.03f, 3);
        }
        else if (39 <= this.time && this.time < 40)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f,0,0);
        }
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " point";
    }
}
