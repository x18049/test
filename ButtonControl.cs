using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPressTitle()
    {
        SceneManager.LoadScene("UnityARKitScene");
    }

    public void ButtonPresstoTitle()
    {
        Debug.Log("押されました");
        SceneManager.LoadScene("Title");
    }

    public void ButtonPresstosousa()
    {
        SceneManager.LoadScene("sousa");
    }
    public void ButtonPresstoGame()
    {
        SceneManager.LoadScene("Gamesousa");
    }


}