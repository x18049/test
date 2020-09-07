using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContrl : MonoBehaviour
{
    int max = 100;
    int currenHp;
    public Slider slider;
    GameObject gm;
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");

        //Sliderを満タンにする。
        slider.value = 1;

        currenHp = max;
        //audioSource = GetComponent<AudioSource>();  //AudioSourceを使えるようにする

        //Debug.Log("Start currentHp : " + currenHp);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision cobj)
   
    {
        if (cobj.gameObject.tag == "Eneny")
        {
            //ダメージは1～100の中でランダムに決める。
            int damage = Random.Range(10, 15);
            //Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            currenHp = currenHp - damage;
            //Debug.Log("After currentHp : " + currenHp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currenHp / (float)max; ;
            //Debug.Log("slider.value : " + slider.value);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(sound1);
            //gameObject.GetComponent<AudioSource>().Play();


            if (currenHp < 0)
            {
                gm.GetComponent<GameManager>().GameOver();
            }
            {

            }
        }
    }
}
