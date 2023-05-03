using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float printSpeed;     //Speed of Dagmae Text
    public float colorSpeed;    //Speed of Vanishing
    public float destroyTime;
    TextMeshPro text;

    public float damage;
    public Color damageColor;

    private void Awake()
    {
        if(GameObject.FindWithTag("GameManager"))
        {
            this.transform.SetParent(GameObject.FindWithTag("GameManager").transform.Find("DamageTextHolder"));
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        text.color = damageColor;
        Invoke("DestroyObject", destroyTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, printSpeed * Time.deltaTime, 0));
        damageColor.a = Mathf.Lerp(damageColor.a, 0, Time.deltaTime * colorSpeed);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
