using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        var pos = transform.position;
        pos.y += Random.Range(-3, 3f);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
