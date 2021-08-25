using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new ObjectManager();

            return Instance;
        }
    }

    private ObjectManager() { }



    //private List<GameObject> EnemyList = new List<GameObject>();
    //EnemyList 를 DisableList 리스트로 교체(ObjectPool)


    //사용가능
    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList 
    { 
        get
        {
            return EnableList;
        }
            
    }

    //사용할수 없는
    private Stack<GameObject> DisableList = new Stack<GameObject>();
    public Stack<GameObject> GetDisableList 
    { 
        get
        {
            return DisableList;
        }
    }


    //private GameObject Player;
    //GameObject ViewObject = new GameObject("EnemyList");



    //Enemy초기 생성
    public void AddObject(GameObject _Object)
    {

        _Object.AddComponent<EnemyController>();

        _Object.transform.parent = GameObject.Find("DisableList").transform;

        //생성된 Enemy의 충돌체에 있는 Trigger기능을 켬
        _Object.GetComponent<SphereCollider>().isTrigger = true;

        _Object.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));

        //x = -25 ~ +25
        //z = -25 ~ +25

        //난수 함수 =  Random.Range(Min, Max)

        //생성된 오브젝트를 비활성화 설정
        //활성화 되지 않은 상태로 DisableList에 넣는다.
        _Object.gameObject.SetActive(false);

        //EnemyList.Add(Obj);
        DisableList.Push(_Object);

    }
}
