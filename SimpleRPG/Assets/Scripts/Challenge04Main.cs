using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge04Main : MonoBehaviour
{
    public Hero hero;
    public Button btnAttack;
    public GameObject fxPrefab;
    public GameObject slimePrefab;
    private List<GameObject> slimes = new List<GameObject>();
    private Slime targetSlime;
    // Start is called before the first frame update
    void Start()
    {
        this.CreateSlimes();

        this.hero.OnAttackComplete = (completeType) => {
            this.OrderHeroAttack();
        };

        this.hero.OnAttackImpact = (impactType) => {
            switch (impactType) {
                case Hero.eAttackType.Attack01:
                    CreateFx();
                    break;
                case Hero.eAttackType.Attack02:
                    CreateFx();
                    break;
            }
        };
        this.btnAttack.onClick.AddListener(() => {
            //this.hero.Attack(this.slime);
            this.OrderHeroAttack();
        });
    }

    private void OrderHeroAttack() {
        var targetGo = this.SearchTarget();
        if (targetGo == null)
        {
            this.hero.Idle();
        }
        else {
            this.targetSlime = targetGo.GetComponent<Slime>();
            this.hero.Attack(this.targetSlime);
        }
    }

    private GameObject SearchTarget() {
        //Å¸°Ù Ã£±â 
        float max = Mathf.Infinity;
        GameObject targetGo = null;

        foreach (var go in slimes)
        {
            var dis = Vector3.Distance(go.transform.position, this.transform.position);
            if (dis < max)
            {
                max = dis;
                targetGo = go;
            }

        }

        //Debug.LogFormat("Å¸°ÙÀ» Ã£¾Ò´Ù! : {0}", targetGo.name);
        return targetGo;
    }

    private void CreateSlimes() {
        for (int i = 0; i < 3; i++) {
            var slimeGo = Instantiate(this.slimePrefab);
            slimeGo.name = string.Format("Slime {0}", i);
            var randX = Random.Range(-5, 5);
            var randZ = Random.Range(-5, 5);
            var initPos = new Vector3(randX, 0, randZ);
            slimeGo.transform.position = initPos;

            slimeGo.GetComponent<Slime>().OnDieAction = () => {
                
                this.slimes.Remove(slimeGo);

            };

            this.slimes.Add(slimeGo);
        }
    }

    private void CreateFx() {
        var fxGo = Instantiate(this.fxPrefab);
        fxGo.transform.position = this.hero.fxPivot.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
