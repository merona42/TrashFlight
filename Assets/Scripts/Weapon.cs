using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    void Start(){
        Destroy(gameObject,1f);
    }
    [SerializeField]
    private float moveSpeed=15f;
    [SerializeField]
    private float damage = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vector3.up * moveSpeed * Time.deltaTime;
    }

    public float getDamage() { return damage; }
}
