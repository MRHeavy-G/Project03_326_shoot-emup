using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject UI_Root;


    // Start is called before the first frame update
    void Start()
    {

        // We will keep the button interaction throught the game
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void LoadScene(string sceneName)
    {
        UI_Root.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
