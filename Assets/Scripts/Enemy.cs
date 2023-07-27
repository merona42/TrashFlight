using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float hp = 1;
    [SerializeField]
    private GameObject coin;
    void Update()
    {
        transform.position+=Vector3.down*moveSpeed*Time.deltaTime;
        if(transform.position.y<-7f){
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Weapon weapon = collision.gameObject.GetComponent<Weapon>();
            hp -= weapon.getDamage();
            if (hp <= 0)
            {
                if (gameObject.tag == "Boss")
                {
                    GameManager.instance.setGameOver();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject);
        }
    }
    public void setMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }


}
