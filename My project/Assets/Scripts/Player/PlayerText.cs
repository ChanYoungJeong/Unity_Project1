using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerText : MonoBehaviour
{
    public float printSpeed;     //Speed of Dagmae Text
    public float colorSpeed;    //Speed of Vanishing
    public float destroyTime;
    TextMeshPro text;

    public string _Text;
    public Color textColor;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = _Text;
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, printSpeed * Time.deltaTime, 0));
        textColor.a = Mathf.Lerp(textColor.a, 0, Time.deltaTime * colorSpeed);
        text.color = textColor;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
