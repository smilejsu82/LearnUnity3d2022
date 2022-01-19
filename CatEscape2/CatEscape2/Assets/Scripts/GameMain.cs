using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public static bool isGameOver = false;
    public PlayerController player;
    public UIGame uiGame;
    public UIGameOver uiGameOver;
    public ArrowGenerator arrowGenerator;
    public Transform leftBoundary;
    public Transform rightBoundary;

    public string[] prefabNames  = { "player_01", "player_02", "player_03"};
    public Dictionary<string, GameObject> dicPrefabs = new Dictionary<string, GameObject>();

    private void Awake()
    {
        foreach (string prefabName in this.prefabNames) {
            GameObject prefab = Resources.Load<GameObject>(prefabName);
            dicPrefabs.Add(prefabName, prefab);
        }
        
    }

    public void Init(string prefabName) {

        var targetPrefab = this.dicPrefabs[prefabName];

        //프리팹을 인스턴스화 
        GameObject playerGo = Instantiate(targetPrefab);

        this.player = playerGo.AddComponent<PlayerController>();  //동적으로 컴포넌트를 부착 할수 있다 

        this.player.Init(10, this.leftBoundary, this.rightBoundary, new Vector3(0, -3.68f, 0));

        //초기화 
        this.uiGameOver.btnRestart.onClick.AddListener(() => {
            //현재씬을 로드함 
            GameMain.isGameOver = false;
            SceneManager.LoadScene("LobbyScene");
        });

        this.player.OnHit = (fillAmount) => {
            this.uiGame.UpdateHpGauge(fillAmount);
        };

        this.player.OnDie = () => {
            if (!GameMain.isGameOver)
            {
                GameMain.isGameOver = true;
                Debug.Log("player is dead");

                this.uiGame.GameOver();
            }
        };
    }

}
