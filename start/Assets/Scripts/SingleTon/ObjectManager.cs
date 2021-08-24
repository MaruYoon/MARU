using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        get
        {
            if (Instance = null)
                Instance = new ObjectManager();

            return Instance;
        }
    }

    private ObjectManager() { }

    public GameObject EnemyPrefab;

    private List<GameObject> EnemyList = new List<GameObject>();

    private GameObject Player;

    //GameObject ViewObject = new GameObject("EnemyList");


    private void Awake()
    {
        GameObject ViewObject = new GameObject("EnemyList");
        EnemyPrefab = Resources.Load("Prefab/Enemy") as GameObject;
    }


    private void Start()
    {

        //Player.transform.position = GameObject.Find("Player").transform.position;

        for (int i = 0; i < 10; ++i)
        {
            GameObject Obj = Instantiate(EnemyPrefab);

            Obj.AddComponent<EnemyController>();

            Obj.transform.parent = GameObject.Find("EnemyList").transform;

            Obj.transform.position = new Vector3(
                Random.Range(-25, 25),
                0.0f,
                Random.Range(-25, 25));

            //x = -25 ~ +25
            //z = -25 ~ +25

            //난수 함수 =  Random.Range(Min, Max)

            EnemyList.Add(Obj);
        }


        //if (Player == Obj)
        //{
        //    Debug.Log("충돌");
        //
        //    // Destroy(Obj);
        //}


    }


}
