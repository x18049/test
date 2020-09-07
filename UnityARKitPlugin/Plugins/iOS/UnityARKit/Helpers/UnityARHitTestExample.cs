using System;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;



namespace UnityEngine.XR.iOS
{
	public class UnityARHitTestExample : MonoBehaviour
	{
		public Transform m_HitTransform;
        public Transform Gametrans;
        //インスペクターウィンドウでUnityChanをセット
        public GameObject unityChan;
		//public float maxRayDistance = 30.0f;
		public LayerMask collisionLayer = 1 << 10;  //ARKitPlane layer
		bool isCreated = false;
        //GameObject ucObject;
        //ARPoint Apoint;
        private Vector3 latestPos;  //前回のPosition
        private Animator anim;// キャラにアタッチされるアニメーターへの参照
        GameObject createtama;
        public GameObject tama;
        public GameObject tamapos;
        public float speed = 100;
        public AudioClip sound1;
        AudioSource audioSource;
        //float x;
        //float z;

        private void Start()
        {
            anim = GetComponent<Animator>();//このスクリプトがアサインされたキャラクターのアニメーターコントローラーを取得

        }

        bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
        {
           

            //平面と当たっていた場合

            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
            if (hitResults.Count > 0 ) {
				foreach (var hitResult in hitResults) {
                    Debug.Log ("Got hit!");
                    if (isCreated == false)
                    {
                        m_HitTransform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                        m_HitTransform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
                        Gametrans.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);

                        this.gameObject.transform.position = m_HitTransform.position;
                        this.gameObject.transform.rotation = m_HitTransform.rotation;
                        anim = GetComponent<Animator>();//このスクリプトがアサインされたキャラクターのアニメーターコントローラーを取得
                        audioSource = GetComponent<AudioSource>();  //AudioSourceを使えるようにする

                        isCreated = true;

                    }
                    //if(Gametrans.position.x > gameObject.transform.position.x && Gametrans.position.z > gameObject.transform.position.z)
                    //{
                    //transform.position += (Vector3.right * x + Vector3.forward * z) * Time.deltaTime;

                    //}

                    //Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));


                    return true;
                }
            }
            return false;
        }



		
		// Update is called once per frame
		void Update () {
            //#if UNITY_EDITOR   //we will only use this script on the editor side, though there is nothing that would prevent it from working on device
            //if (Input.GetMouseButtonDown (0)) {
            //	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            //	RaycastHit hit;

            //	//we'll try to hit one of the plane collider gameobjects that were generated by the plugin
            //	//effectively similar to calling HitTest with ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent
            //	if (Physics.Raycast (ray, out hit, maxRayDistance, collisionLayer)) {
            //		//we're going to get the position from the contact point
            //		m_HitTransform.position = hit.point;
            //		Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));

            //		//and the rotation from the transform of the plane collider
            //		m_HitTransform.rotation = hit.transform.rotation;
            //	}
            //}
            //#else
            // x = CrossPlatformInputManager.GetAxis("Horizontal");//左右移動
            // z = CrossPlatformInputManager.GetAxis("Vertical");//上下移動
            //Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
            //latestPos = transform.position;  //前回のPositionの更新

            //if (x > 0.1 || x < -0.1 || z > 0.1 || z < -0.1)
            //{

            //    //プレイヤーの移動
            //    //transform.position += (Vector3.right * x + Vector3.forward * z) * Time.deltaTime;

            //    anim.SetBool("RUN", true);

            //}
            //else
            //{
            //    anim.SetBool("RUN", false);

            //}




            if ((Input.touchCount > 0 && m_HitTransform != null) || isCreated == false)
			{
				var touch = Input.GetTouch(0);
				if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) )
				{
					var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
					ARPoint point = new ARPoint {
						x = screenPosition.x,
						y = screenPosition.y
					};
					 

                    // prioritize reults types
                    ARHitTestResultType[] resultTypes = {
						//ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingGeometry,
                        ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                        // if you want to use infinite planes use this:
                        //ARHitTestResultType.ARHitTestResultTypeExistingPlane,
                        //ARHitTestResultType.ARHitTestResultTypeEstimatedHorizontalPlane,
                        //ARHitTestResultType.ARHitTestResultTypeEstimatedVerticalPlane,
                        //ARHitTestResultType.ARHitTestResultTypeFeaturePoint
                    }; 
					
                    foreach (ARHitTestResultType resultType in resultTypes)
                    {
                        if (HitTestWithResultType (point, resultType))
                        {
                            return;
                        }
                    }
				}

                isCreated = true;


            }
            //#endif
    //        else
    //        {
    //         var sposition = Camera.main.ScreenToViewportPoint(this.gameObject.transform.position);
				//sposition.z = 0;
    //        ARPoint Apoint = new ARPoint
    //        {
    //            x = sposition.x,
    //            y = sposition.y
    //        };
    //        // prioritize reults types
    //        ARHitTestResultType[] resultTypes = {
				//		//ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingGeometry,
    //                    ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
    //                    // if you want to use infinite planes use this:
    //                    //ARHitTestResultType.ARHitTestResultTypeExistingPlane,
    //                    //ARHitTestResultType.ARHitTestResultTypeEstimatedHorizontalPlane,
    //                    //ARHitTestResultType.ARHitTestResultTypeEstimatedVerticalPlane,
    //                    //ARHitTestResultType.ARHitTestResultTypeFeaturePoint
    //                };

    //            foreach (ARHitTestResultType resultType in resultTypes)
    //            {
    //                if (HitTestWithResultType(Apoint, resultType))
    //                {
    //                    return;
    //                }
    //            }
    //        }
            //if (x > 0.1 || x < -0.1 || z > 0.1 || z < -0.1)
            //{

            //    //プレイヤーの移動
            //    //transform.position += (Vector3.right * x + Vector3.forward * z) * Time.deltaTime;

            //    anim.SetBool("RUN", true);

            //}
            //else
            //{
            //    anim.SetBool("RUN", false);

            //}
            //if (diff.magnitude > 0.01f)
            //{
            //    transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
            //}

            //if (CrossPlatformInputManager.GetButtonDown("shot"))
            //{

            //    Debug.Log("攻撃しました");
            //    createtama = Instantiate(tama);
            //    createtama.transform.position = tamapos.transform.position;
            //    Vector3 force;
            //    force = tamapos.transform.forward * speed;
            //    //gameObject.GetComponent<AudioSource>().Play();

            //    createtama.GetComponent<Rigidbody>().AddForce(force);
            //    audioSource.PlayOneShot(sound1);

            //    Destroy(createtama, 2f);

            //}
        }

	
	}
}

