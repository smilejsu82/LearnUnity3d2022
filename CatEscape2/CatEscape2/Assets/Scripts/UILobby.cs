using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    public Button[] arrBtns;
    public System.Action<string> onSelectedPlayer;
    void Start()
    {
        for (int i = 0; i < arrBtns.Length; i++) {
            int idx = i;
            Button btn = this.arrBtns[idx];
            btn.onClick.AddListener(() => {
                string prefabName = string.Format("player_0{0}", idx+1);
                Debug.LogFormat("prefabName: {0}", prefabName);
                this.onSelectedPlayer(prefabName);
            });
        }
    }
}
