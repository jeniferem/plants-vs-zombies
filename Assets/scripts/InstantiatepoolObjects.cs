using UnityEngine;
using System.Collections.Generic;
public class InstantiatepoolObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;

    private List<GameObject> objectPool = new List<GameObject>();
    private GameObject currentObject;
    public void InstantiatepoolObject(Transform target)
    {
        currentObject = GetPoolObject();
        if (currentObject != null)
        {
            currentObject.transform.position = target.position;
            currentObject.transform.rotation = target.rotation;
            currentObject.SetActive(true);
        }
    }
    public void InstantiatepoolObject(Vector3 position)
    {
        currentObject = GetPoolObject();
        if (currentObject != null)
        {
            currentObject.transform.position = position;
            currentObject.transform.rotation = Quaternion.identity;
            currentObject.SetActive(true);
        }
    }
    private GameObject GetPoolObject()
    {
        foreach (var obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject newObj = Instantiate(Prefab);
        newObj.SetActive(false);
        objectPool.Add(newObj);
        return newObj;
    }
}
