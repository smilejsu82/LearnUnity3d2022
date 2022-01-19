using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMain : MonoBehaviour
{
    public UILobby uiLobby;
    
    // Start is called before the first frame update
    void Start()
    {
        this.uiLobby.onSelectedPlayer = (prefabName) => {
            
            //씬전환 
            //SceneManager.LoadScene("GameScene");    //동기 

            //비동기 
            AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");
            operation.completed += (oper) => {
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
                gameMain.Init(prefabName);
            };
            
        };    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
