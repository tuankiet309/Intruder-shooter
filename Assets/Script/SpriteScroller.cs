using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
