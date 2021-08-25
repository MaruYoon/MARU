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
    //EnemyList �� DisableList ����Ʈ�� ��ü(ObjectPool)


    //��밡��
    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList 
    { 
        get
        {
            return EnableList;
        }
            
    }

    //����Ҽ� ����
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



    //Enemy�ʱ� ����
    public void AddObject(GameObject _Object)
    {

        _Object.AddComponent<EnemyController>();

        _Object.transform.parent = GameObject.Find("DisableList").transform;

        //������ Enemy�� �浹ü�� �ִ� Trigger����� ��
        _Object.GetComponent<SphereCollider>().isTrigger = true;

        _Object.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));

        //x = -25 ~ +25
        //z = -25 ~ +25

        //���� �Լ� =  Random.Range(Min, Max)

        //������ ������Ʈ�� ��Ȱ��ȭ ����
        //Ȱ��ȭ ���� ���� ���·� DisableList�� �ִ´�.
        _Object.gameObject.SetActive(false);

        //EnemyList.Add(Obj);
        DisableList.Push(_Object);

    }
}
