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

            int terrainLayerMask = LayerMask.GetMask("Terrain");//���� �߰��� �κ�. ������ Ŭ���Ϸ��� �ߴµ� ����� ��ź�� �߰��� ���ļ� Ŭ���Ǹ� �� ����� �������� ��ǥ�� �ٽ����� �̵��Ǵ� ���� ������. Stage������Ʈ�� Terrain���̾ �����ϰ� �� �ڵ带 �߰��ϸ� ray�� Terrain���̾ �ִ� ������Ʈ�͸� ��ȣ�ۿ���.

            if (Physics.Raycast(ray,out hit, Mathf.Infinity, terrainLayerMask))//���� �߰��� �κ�. ������ Ŭ���Ϸ��� �ߴµ� ����� ��ź�� �߰��� ���ļ� Ŭ���Ǹ� �� ����� �������� ��ǥ�� �ٽ����� �̵��Ǵ� ���� ������.
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
        
    }

    
}
