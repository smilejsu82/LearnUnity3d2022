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
            
            //����ȯ 
            //SceneManager.LoadScene("GameScene");    //���� 

            //�񵿱� 
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
