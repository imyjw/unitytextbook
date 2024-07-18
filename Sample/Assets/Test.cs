using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int hp=100;
    private int power=50;

    public void Attack()
    {
        Debug.Log(this.power+"데미지를 입혔다");
    }

    public void Damage(int damage)
    {
        this.hp-=damage;
        Debug.Log(damage+"데미지를 입었다");
    }


}


public class Test : MonoBehaviour
{
    void Start()
    {
        Player myPlayer=new Player();
        myPlayer.Attack();
        myPlayer.Damage(30);

        Vector2 startPos=new Vector2(3.0f,5.0f);
        Vector2 endPos=new Vector2(7.0f,9.0f);
        Vector2 dir=endPos-startPos;
        Debug.Log(dir);

        float len=dir.magnitude;
        Debug.Log(len);
    }
}
