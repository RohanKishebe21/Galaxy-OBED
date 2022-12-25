using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ship : MonoBehaviour
{
    public delegate void OnDeath(Enemy_ship deadShip);
    public event OnDeath DeathIvent;
    public int health = 200;
    public GameObject bullet;
    void OnTriggerEnter2D(Collider2D collider) {

        GameObject otherObject = collider.gameObject;
        Bullet bulletObject = otherObject.GetComponent<Bullet>();

        if(bulletObject != null){
            health -= bulletObject.damage; 
            if (health <=0 ){
                DeathIvent.Invoke(this);
                Destroy(gameObject);
            }    
            Destroy(collider.gameObject);
        }
    }

    public void Shoot(){
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = transform.position;
    }

}   




