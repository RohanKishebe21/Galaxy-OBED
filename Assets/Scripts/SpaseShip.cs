using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaseShip : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer spriteRenderer;
    float health = 25;
    float speed =0.4f;

    void Start()
    {
        
    }
    void Update()
    {
        float halfWidth = spriteRenderer.bounds.size.x / 2;

        bool isKeyDown =  Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A);
        if(isKeyDown == true)
        {
            Vector3 newPosition = new Vector3(transform.position.x -speed, transform.position.y, 0);
            Vector3 checkPosition = new Vector3(
                newPosition.x - halfWidth,
                newPosition.y,
                0
            );
            if(ScreenHelpers.ScreenPosition(checkPosition)){
                transform.position = newPosition;
            }

        }

        isKeyDown =  Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D);
        if(isKeyDown == true)
        {
            Vector3 newPosition = new Vector3(transform.position.x +speed, transform.position.y, 0);
            Vector3 checkPosition = new Vector3(
                newPosition.x + halfWidth,
                newPosition.y,
                0
            );
            if(ScreenHelpers.ScreenPosition(checkPosition)){
                transform.position = newPosition;
            }

        }
        isKeyDown = Input.GetKey(KeyCode.Space);

        if (isKeyDown == true){
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        GameObject otherObject = collider.gameObject;
        EnemyBullet bullet = otherObject.GetComponent<EnemyBullet>();
        if(bullet != null){
            health -= bullet.damage;
            Destroy(otherObject);
            if(health <= 0){
                SceneManager.LoadSceneAsync(SceneIDS.loseSceneID);
                Destroy(gameObject);
            }
        }
    }
}
