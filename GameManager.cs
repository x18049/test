using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    GameObject countText;
    GameObject statusText;
    public GameObject unitychan;
    private UnityARAnchorManager unityAnchor;
    int enenycount = 0;
    GameObject create;
    int createcount;
    GameObject box;
    int count;

    //public GameObject Eneny;

    int life = 3; //ライフ
    bool endFlag = false; //ゲームオーバー⽤フラグ
    bool clearFlag = false; //ゲームクリア⽤フラグ
    bool Flag = false;
    bool eney = false;
    
    // Start is called before the first frame update
    void Start()
    {


        box = GameObject.Find("cubecreate");
        countText = GameObject.Find("count");


        //this.countText.GetComponent<Text>().text = "" + enenycount;



        unitychan.SetActive(false);
        //Eneny.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("Eneny");
        createcount = enemyUnits.Length;
        this.countText.GetComponent<Text>().text = "" + createcount;



        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began )
        {
            unitychan.SetActive(true);


            Flag = true;

        }
     
          //this.gameObject.GetComponent<AudioSource>().Play();
        



        if (enemyUnits.Length == 0 && Flag== true)
        {

            //敵全滅時の処理
            GameClear();
        }




    }
    public void Decreasecount()
    {
        enenycount--;
        this.countText.GetComponent<Text>().text = "LIFE : " + enenycount;
        
    }
    public void GameOver()
    {
        //テキスト表⽰
        Debug.Log("Game Over!");
      
        SceneManager.LoadScene("GameOver");
       
        //平面オブジェクト削除
        unityAnchor.Destroy();
    }
  


    public void GameClear()
    {
        //テキスト表⽰
        Debug.Log("Game clear!");
      

        SceneManager.LoadScene("Gameclear");
        unityAnchor.Destroy();
    }
   

}
