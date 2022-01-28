using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̱��� Ŭ���� 
public class DataManager
{
    //���� �ɹ� 
    private static DataManager instance;
    Dictionary<int, WeaponData> dicWeaponDatas;

    //private ������ 
    private DataManager() { 
        this.dicWeaponDatas = new Dictionary<int, WeaponData>();
    }

    //���� method �� ���ؼ� �ν��Ͻ��� ��ȯ�ϴ� �޼��� ���� 
    public static DataManager GetInstance() {
        //�ν��Ͻ��� 1������ �Ѵ� 
        if (DataManager.instance == null) {
            DataManager.instance = new DataManager();
        } 
        return DataManager.instance;
    }

    //�ν��Ͻ� �޼��� �����͸� �ε��� 
    public void LoadWeaponData() {

        string path = "Data/weapon_data";
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        string json = textAsset.text;

        WeaponData[] arrWeaponDatas = JsonConvert.DeserializeObject<WeaponData[]>(json);
        for (int i = 0; i < arrWeaponDatas.Length; i++)
        {
            WeaponData weaponData = arrWeaponDatas[i];
            Debug.LogFormat("{0} {1} {2} {3}", weaponData.id, weaponData.name, weaponData.damage, weaponData.prefabName);
            dicWeaponDatas.Add(weaponData.id, weaponData);
        }
    }

    public WeaponData GetWeaponData(int id) {
        return this.dicWeaponDatas[id];
    }
}
