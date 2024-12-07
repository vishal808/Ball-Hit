using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector2 mousePos;
    private float width;
    private float height;
    Vector2 pos;
    public GameObject[] ballObjects;
    public GameObject dirPointer;
    int idx = 0;
    bool ball_shoot=false;
    float nextTime = 0.0f;
    bool ballShootDone = false;
    Vector2 newPos;
    bool gotNewPos = false;
    void Awake()
    {
        width = (float)Screen.width;
        height = (float)Screen.height;
    }


    void Start()
    {
        Vector3 ballpos = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
       
    }

    void Update()
    {
    if (Input.touchCount == 1)
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            dirPointer.SetActive(true);
            pos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 dir = pos - (Vector2)transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (touch.phase == TouchPhase.Ended)
        {
            ball_shoot = true;
            }
    }

        if (ball_shoot && Time.time > nextTime && ballShootDone==false)
        {
            ballObjects[idx].GetComponent<Rigidbody2D>().velocity = transform.up * 8f;
            nextTime = Time.time + 0.2f;
            idx++;
        }

        if (idx >= ballObjects.Length)
        {
            idx = 0;
            ball_shoot = false;
            dirPointer.SetActive(false);
        }

        if(ballObjects[0].transform.position.y<transform.position.y){
           newPos = new Vector2(ballObjects[0].transform.position.x,transform.position.y);
        }


        if(ballObjects[ballObjects.Length-1].transform.position.y<transform.position.y)
         {   ballShootDone = true;
         }

        if (ballShootDone)
        {
            StartCoroutine(BallPosSet());
        }
    
    }

    
    IEnumerator BallPosSet(){
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<ballObjects.Length;i++){
            ballObjects[i].transform.position = newPos;
            ballObjects[i].GetComponent<Ball>().ballStop = false;
        }
        transform.position = newPos;
        ballShootDone = false;
        gotNewPos = false;
    }
}