using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Change object's script into size of camera
public class Scale_Controller : MonoBehaviour
{
    public GameObject Image;

    float leftPosX = 0f;
    float rightPosX = 0f;
    float xScreenHalfSize;
    float yScreenHalfSize;

    // Start is called before the first frame update
    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);

        float spritex = Image.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float spritey = Image.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        Image.transform.localScale = new Vector3(((xScreenHalfSize * 2) / spritex), (yScreenHalfSize * 2) / spritey, Image.transform.localScale.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
