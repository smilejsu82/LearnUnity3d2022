using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestJsonMain : MonoBehaviour
{
    public Button btn;
    public GameObject slimeGo;
    public int dropItemId = 100;
    private UnityAction dieAction;


    void Start()
    {
        //데이터 로드 
        DataManager.GetInstance().LoadWeaponData();

        //델리게이트 메서드 연결 
        this.dieAction = () => {

            //WeaponData 가져오기 
            WeaponData weaponData = DataManager.GetInstance().GetWeaponData(this.dropItemId);   //데이터 가져오기 
            GameObject prefab = Resources.Load<GameObject>(weaponData.prefabName);  //프리팹 로드 
            GameObject prefabClone = Instantiate<GameObject>(prefab);   //프리팹 인스턴스화 
            prefabClone.transform.position = this.slimeGo.transform.position;   //위치 설정 
            //슬라임 제거 
            Destroy(this.slimeGo);
        };

        //버튼 이벤트 등록 
        this.btn.onClick.AddListener(() => {
            this.StartCoroutine(this.DieRoutine());
        });

    }

    private IEnumerator DieRoutine()
    {
        this.slimeGo.GetComponent<Animator>().Play("Die");

        yield return new WaitForSeconds(1.333f);

        Debug.Log("Die 애니메이션 종료");

        this.dieAction();
    }
}
