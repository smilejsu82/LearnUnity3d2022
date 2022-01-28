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
        //������ �ε� 
        DataManager.GetInstance().LoadWeaponData();

        //��������Ʈ �޼��� ���� 
        this.dieAction = () => {

            //WeaponData �������� 
            WeaponData weaponData = DataManager.GetInstance().GetWeaponData(this.dropItemId);   //������ �������� 
            GameObject prefab = Resources.Load<GameObject>(weaponData.prefabName);  //������ �ε� 
            GameObject prefabClone = Instantiate<GameObject>(prefab);   //������ �ν��Ͻ�ȭ 
            prefabClone.transform.position = this.slimeGo.transform.position;   //��ġ ���� 
            //������ ���� 
            Destroy(this.slimeGo);
        };

        //��ư �̺�Ʈ ��� 
        this.btn.onClick.AddListener(() => {
            this.StartCoroutine(this.DieRoutine());
        });

    }

    private IEnumerator DieRoutine()
    {
        this.slimeGo.GetComponent<Animator>().Play("Die");

        yield return new WaitForSeconds(1.333f);

        Debug.Log("Die �ִϸ��̼� ����");

        this.dieAction();
    }
}
