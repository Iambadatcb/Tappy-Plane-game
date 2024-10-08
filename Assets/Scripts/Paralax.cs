using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float speed = 0.5f;

    private Renderer renderer;

    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
       renderer = GetComponent<Renderer>();
        offset = renderer.material.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speed * Time.deltaTime;
        renderer.material.mainTextureOffset = offset;
    }
}
