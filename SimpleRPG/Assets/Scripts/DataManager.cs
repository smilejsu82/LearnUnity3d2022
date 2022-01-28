using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//싱글톤 클래스 
public class DataManager
{
    //정적 맴버 
    private static DataManager instance;
    Dictionary<int, WeaponData> dicWeaponDatas;

    //private 생성자 
    private DataManager() { 
        this.dicWeaponDatas = new Dictionary<int, WeaponData>();
    }

    //정적 method 를 통해서 인스턴스를 반환하는 메서드 정의 
    public static DataManager GetInstance() {
        //인스턴스는 1개여야 한다 
        if (DataManager.instance == null) {
            DataManager.instance = new DataManager();
        } 
        return DataManager.instance;
    }

    //인스턴스 메서드 데이터를 로드함 
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
