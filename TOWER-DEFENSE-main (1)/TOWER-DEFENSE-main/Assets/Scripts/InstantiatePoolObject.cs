using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiatePoolObject : MonoBehaviour
{
    [SerializeField]
    public GameObject _prefab;

    [SerializeField]
    public Transform _parent;
    private List<GameObject> _pool = new List<GameObject>();

    private GameObject _currentObject;

    private GameObject GetObject()
    {
        foreach (var obj in _pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        var newObj = Instantiate(_prefab);
        _pool.Add(newObj);
        return newObj;
    }
    public GameObject GetCurrentObject()
    {
        return _currentObject;
    }

    public void InstantiateObject(Transform target)
    {
        _currentObject = GetObject();
        SetObjectPosition(_currentObject, target.position, target.rotation);
    }

    public void InstatiateObject(Vector3 position)
    {
        _currentObject = GetObject();
        SetObjectPosition(_currentObject, position, Quaternion.identity);
    }

    public void SetObjectPosition(GameObject obj, Vector3 position, Quaternion rotation)
    {
        if (_parent != null)
        {
            obj.transform.SetParent(_parent);
            obj.transform.SetLocalPositionAndRotation(position, rotation);
        }
        else
        {
            obj.transform.SetPositionAndRotation(position, rotation);
        }
        obj.SetActive(true);
    }

    public void DesactivateAllObjects()
    {
        foreach (var obj in _pool)
        {
            obj.SetActive(false);
        }
    }
}
