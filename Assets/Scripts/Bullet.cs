using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int damage = 30;
    float speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(
         transform.position.x,
         transform.position.y + speed, 
         0
        );
        if(transform.position.y > 5)
        {
            Destroy(gameObject);
        }
        
    }
}
