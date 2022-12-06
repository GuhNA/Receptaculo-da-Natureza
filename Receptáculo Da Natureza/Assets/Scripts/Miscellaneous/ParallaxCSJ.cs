using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ParallaxCSJ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float parallaxEffect;
    float startPos;
    float length;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float rePos = Camera.main.transform.position.x * (1 - parallaxEffect);
        float distance = Camera.main.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(rePos > startPos + length)
        {
            startPos += length;
        }
        else if(rePos < startPos - length)
        {
            startPos -= length;
        }
    }
}
