using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    Monster_Combat deadscript;
    public float printSpeed;     //Speed of Dagmae Text
    public float colorSpeed;    //Speed of Vanishing
    public float destroyTime;
    TextMeshPro text;

    public float damage;
    public Color damageColor;

    
    // Start is called before the first frame update
    void Start()
    {
        deadscript =this.GetComponent<Monster_Combat>();
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, printSpeed * Time.deltaTime, 0));
        damageColor.a = Mathf.Lerp(damageColor.a, 0, Time.deltaTime * colorSpeed);
        text.color = damageColor;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
