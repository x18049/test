using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.XR.iOS;
using UnityEngine.UI;


public class Plyermove : MonoBehaviour
{
    private Vector3 velocity;// キャラクターの移動量
    private Vector3 latestPos;  //前回のPosition
    private Animator anim;// キャラにアタッチされるアニメーターへの参照
    public float rotateSpeed = 1.0f; // 旋回速度
    GameObject tamaP;
    public GameObject tama;
    public GameObject tamapos;
    public float speed = 100;
    GameObject createtama;
    GameObject gm;
    private UnityARAnchorManager unityAnchor;
    public GameObject hit;
    public AudioClip sound1;
    AudioSource audioSource;
    public float lapseTime;
    bool isAttackable;
    GameObject eneny;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();//このスクリプトがアサインされたキャラクターのアニメーターコントローラーを取得
        gm = GameObject.Find("GameManager");
        //audioSource = GetComponent<AudioSource>();  //AudioSourceを使えるようにする
        
        isAttackable = true;
        lapseTime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");//左右移動
        float z = CrossPlatformInputManager.GetAxis("Vertical");//上下移動
        Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新
        lapseTime += Time.deltaTime;
        


        if (x > 0.1 || x < -0.1 || z > 0.1 || z < -0.1)
        {

            //プレイヤーの移動
            transform.position += (Vector3.right * x + Vector3.forward * z) * Time.deltaTime;

            anim.SetBool("RUN", true);

        }
        else
        {
            anim.SetBool("RUN", false);

        }
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }

        if (CrossPlatformInputManager.GetButtonDown("shot") && lapseTime>=1)
        {

            //Debug.Log("攻撃しました");
            createtama = Instantiate(tama);
            createtama.transform.position = tamapos.transform.position;
            Vector3 force;
            force = tamapos.transform.forward * speed;
            //gameObject.GetComponent<AudioSource>().Play();
            createtama.GetComponent<Rigidbody>().AddForce(force);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(sound1);

            Destroy(createtama, 1f);
            lapseTime = 0.0f;
            //isAttackable = false;

        }

       　　　 Vector3 vFloor = unityAnchor.GetCurrentPlaneAnchors()[0].gameObject.transform.position;
            Vector3 Ptrans = this.gameObject.transform.position;
            if (Ptrans.y < vFloor.y)
            {
                this.gameObject.transform.position = new Vector3(vFloor.x, (float)(vFloor.y + 0.2f), vFloor.z);
            }
            clamp();



        }
        void clamp()
        {
            Vector3 vFloor = unityAnchor.GetCurrentPlaneAnchors()[0].gameObject.transform.position;
            Vector3 sFloor = unityAnchor.GetCurrentPlaneAnchors()[0].gameObject.transform.localScale;
            Vector3 trans = transform.position;
            trans.x = Mathf.Clamp(this.gameObject.transform.position.x, ((float)-sFloor.x / 2f) * 10, ((float)sFloor.x / 2f) * 10);
            trans.z = Mathf.Clamp(this.gameObject.transform.position.z, ((float)-sFloor.z / 2f) * 10, ((float)sFloor.z / 2f) * 10);
            this.gameObject.transform.position = (new Vector3(Mathf.Clamp(this.gameObject.transform.position.x, -sFloor.x / 2, sFloor.x / 2), (this.gameObject.transform.position.y), Mathf.Clamp(this.gameObject.transform.position.z, -sFloor.z / 2, sFloor.z / 2)));
            transform.position = trans;

        }

        void OnCollisionEnter(Collision cobj)
        {
            if (cobj.gameObject.tag == "Eneny")
            {
                Destroy(createtama);


            }
        }
 }

