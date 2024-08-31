using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    public float delta = 0;
    public float span = 1.0f;
    public int ratio = 3;
    public float speed = -0.03f;
    // Start is called before the first frame update

    
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (this.delta>this.span)
        {
            this.delta = 0;
            GameObject item;

            float dice = Random.Range(1, 11);
            if (dice>this.ratio)
            {
                item = Instantiate(applePrefab);
            }
            else
            {
                item = Instantiate(bombPrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;

        }
    }
}
