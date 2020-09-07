using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.iOS;

public class Boxcreate : MonoBehaviour
{
    public GameObject cube;
    public GameObject go;
    public GameObject tree;
    public GameObject Eneny;
    public GameObject cube2;
    private UnityARAnchorManager unityAnchor;
    float R = 1;
    bool created = false;
    int l = 0;
    int number = 0;
    int enenycount;


    // Start is called before the first frame update
    void Start()
    {
        unityAnchor = new UnityARAnchorManager();


        l = Random.Range(4, 8);
        number = Random.Range(1, 3);

    }
 

    // Update is called once per frame
    void Update()
    {
        if (created == false)
        {
            if (unityAnchor.GetCurrentPlaneAnchors().Count != 0)
            {

                Vector3 vFloor = unityAnchor.GetCurrentPlaneAnchors()[0].gameObject.transform.position;
                //for (int i = 0; i < 5; i++)
                //{
                //    //Vector3 transB = box.transform.position + new Vector3(0, 1, 0);
                //    GameObject box = Instantiate(cube) as GameObject;
                //    box.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y , vFloor.z + Random.Range((float)-0.5, (int)0.5));
                //}

                //for(int j = 0; j < 3; j++)
                //{
                //    GameObject box2 = Instantiate(go) as GameObject;
                //    box2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y , vFloor.z + Random.Range((float)-0.5, (int)0.5));

                //}

                //    GameObject tree2 = Instantiate(tree) as GameObject;
                //    tree2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y , vFloor.z + Random.Range((float)0, (int)0.4));
                //for ( k = 0; k < 9; k++)
                //{
                //    GameObject Eneny2 = Instantiate(Eneny) as GameObject;
                //    Vector3 scale;
                //    scale.x = 0.1f;
                //    scale.y = 0.1f;
                //    scale.z = 0.1f;
                //    Eneny2.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                //    Eneny2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y + (float)0.025, vFloor.z + Random.Range((float)-0.3, (int)0.3));
                //}
                switch (number)
                {
                    case 1:
                        //木箱生成
                        //for (int i = 0; i < 10; i++)
                        //{
                        //    //Vector3 transB = box.transform.position + new Vector3(0, 1, 0);
                        //    GameObject box = Instantiate(cube) as GameObject;
                        //    box.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y, vFloor.z + Random.Range((float)-0.5, (int)0.5));
                        //}
                        for (int k = 0; k < 2; k++)
                        {
                            GameObject tree2 = Instantiate(tree) as GameObject;
                            tree2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.8, (float)0.8), vFloor.y, vFloor.z + Random.Range((float)-0.8, (int)0.8));
                        }
                        //石生成
                        for (int i = 0; i < 5; i++)
                        {
                            GameObject rock = Instantiate(cube2) as GameObject;
                            rock.transform.position = new Vector3(vFloor.x + Random.Range((float)-1, (float)1), vFloor.y + (float)0.025, vFloor.z + Random.Range((float)-1, (int)1));

                        }
                        //敵キャラ生成
                        for (int k = 0; k < l; k++)
                        {
                            GameObject Eneny2 = Instantiate(Eneny) as GameObject;
                            Vector3 scale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            scale.z = 0.1f;
                            Eneny2.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                            Eneny2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y + (float)0.025, vFloor.z + Random.Range((float)-0.3, (int)0.3));
                        }

                        break;

                    case 2:
                        //樽の生成
                        for (int j = 0; j < 5; j++)
                        {
                            GameObject box2 = Instantiate(go) as GameObject;
                            box2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y, vFloor.z + Random.Range((float)-0.5, (int)0.5));

                        }
                        //石生成
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject rock = Instantiate(cube2) as GameObject;
                            rock.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y + (float)0.025, vFloor.z + Random.Range((float)-0.5, (int)0.5));

                        }
                        //敵キャラ生成
                        for (int k = 0; k < l; k++)
                        {
                            GameObject Eneny2 = Instantiate(Eneny) as GameObject;
                            Vector3 scale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            scale.z = 0.1f;
                            Eneny2.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                            Eneny2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y + (float)0.025, vFloor.z + Random.Range((float)-0.3, (int)0.3));


                        }

                        break;
                    case 3:
                        //石生成
                        for (int i = 0; i < 5; i++)
                        {
                            GameObject rock = Instantiate(cube2) as GameObject;
                            rock.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.7, (float)0.7), vFloor.y + (float)0.025, vFloor.z + Random.Range((float)-0.7, (int)0.7));

                        }
                        //敵キャラ生成
                        for (int k = 0; k < l; k++)
                        {
                            GameObject Eneny2 = Instantiate(Eneny) as GameObject;
                            Vector3 scale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            scale.z = 0.1f;
                            Eneny2.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                            Eneny2.transform.position = new Vector3(vFloor.x + Random.Range((float)-0.5, (float)0.5), vFloor.y + (float)0.025, vFloor.z + Random.Range((float)-0.3, (int)0.3));


                        }
                        break;
                }
                created = true;

            }
        }
    }
}
