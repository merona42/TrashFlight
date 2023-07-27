using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;
    private int weaponIdx = 0;
    [SerializeField]
    private Transform shootTransForm;
    [SerializeField]
    private float shootInterval;
    private float lastShootTime;
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Vector3 moveTo = new Vector3(horizontalInput,0,0);
        // transform.position+=moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime,0,0);
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position-=moveTo;
        // }
        // else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.position+=moveTo;
        // }

        Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX=Mathf.Clamp(mousePos.x,-2.8f,2.8f);
        transform.position=new Vector3(toX,transform.position.y,transform.position.z);
        if (GameManager.instance.getIsGameOver() == false)
        {
            shoot();
        }
        
    }

    void shoot(){
        if(Time.time-lastShootTime>shootInterval){
            Instantiate(weapons[weaponIdx],shootTransForm.position,Quaternion.identity);
            lastShootTime=Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag=="Boss")
        {
            GameManager.instance.setGameOver();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Coin")
        {
            GameManager.instance.addCoin();
            Destroy(collision.gameObject);
        }
    }

    public void upgrade()
    {
        if (weaponIdx < weapons.Length - 1) weaponIdx++;
    }
}
