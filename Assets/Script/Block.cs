using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public int MaxTakeHits = 5;
    public TMP_Text text;
    SpriteRenderer sprite;
    public Color[] Block_colors;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Block_colors[Random.Range(0,Block_colors.Length)];
        MaxTakeHits = Random.Range(2,MaxTakeHits);
        text.text = MaxTakeHits.ToString();
    }


    public void OnCollisionEnter2D(Collision2D other){
        if(other.transform.tag == "Ball"){
            MaxTakeHits--;
            if(MaxTakeHits<1){
                gameObject.SetActive(false);
            }
            text.text = MaxTakeHits.ToString();
        }

    }
}
