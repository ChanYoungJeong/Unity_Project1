using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public GameObject Map;
    public Sprite[] Maps;

    SpriteRenderer sprite;
    private void Awake()
    {
        sprite = Map.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.sprite = Maps[(Game_System.Stage / 3)];
    }

}
