using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
        }
        if (other.gameObject.tag == "Bomb")
        {
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int terrainLayerMask = LayerMask.GetMask("Terrain");//내가 추가한 부분. 지형을 클릭하려고 했는데 사과나 폭탄이 중간에 겹쳐서 클릭되면 그 사과가 떨어지는 좌표로 바스켓이 이동되는 버그 때문에. Stage오브젝트에 Terrain레이어를 설정하고 이 코드를 추가하면 ray가 Terrain레이어에 있는 오브젝트와만 상호작용함.

            if (Physics.Raycast(ray,out hit, Mathf.Infinity, terrainLayerMask))//내가 추가한 부분. 지형을 클릭하려고 했는데 사과나 폭탄이 중간에 겹쳐서 클릭되면 그 사과가 떨어지는 좌표로 바스켓이 이동되는 버그 때문에.
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
        
    }

    
}
