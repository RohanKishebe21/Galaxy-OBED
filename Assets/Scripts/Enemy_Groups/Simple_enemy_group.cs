using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_enemy_group : MonoBehaviour
{
    public Enemy_ship ship1;
    public Enemy_ship ship2;
    public Enemy_ship ship3;
    public bool isAlive = true;
    private List<Enemy_ship> ships = new List<Enemy_ship>();
    private float speed = 0.1f;
    private int derection = -1;
    private System.Random generator = new System.Random();

    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);

        ship1.DeathIvent += OnShipDeath;
        ship2.DeathIvent += OnShipDeath;
        ship3.DeathIvent += OnShipDeath;

        InvokeRepeating("GroupShoot",0.0f, 1);
        
    }

    
    void Update()
    {
        ships.RemoveAll(item => item == null);
       
        if(ships.Count == 0)
        {
            isAlive = false;
            CancelInvoke("GroupShoot");
            return;
        }

        if (derection == -1){
            Vector3 leftPosition = ships[0].transform.position;
            leftPosition.x -=speed;

            bool onScreen = ScreenHelpers.ScreenPosition(leftPosition);
            if (onScreen){
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            } else{
               derection *= -1;
            }
        }else {
            Vector3 rightPosition = ships[ships.Count - 1].transform.position;
            rightPosition.x += speed;
            bool onScreen = ScreenHelpers.ScreenPosition(rightPosition);
            if (onScreen){
                transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    0
                );
            } else{
               derection *= -1;
            }
        }

    }
    void OnShipDeath (Enemy_ship deadShip){
        //ships.Remove(deadShip);
    }
    void GroupShoot(){
        int RandomIndex = generator.Next(0, ships.Count);
        ships[RandomIndex].Shoot();
    }
}


