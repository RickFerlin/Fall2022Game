using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
  public GameObject prefab;
  private int num;
  
  public void CreateInstance()
  {
    Instantiate(prefab);
  }

  public void CreateInstance(Vector3Data obj)
  {
    Instantiate(prefab, obj.value, quaternion.identity);
  }

  public void CreateInstanceFromList(Vector3DataList obj)
  {
    foreach (var t in obj.vector3List)
    {
      Instantiate(prefab, t.value, quaternion.identity);
    }
  }

  public void CreateInstanceFromListCounting(Vector3DataList obj)
  {
    Instantiate(prefab, obj.vector3List[num].value, quaternion.identity);
    num++;
    if (num == obj.vector3List.Count)
    {
      num = 0;
    }
  }
  
  public void CreateInstanceListRandomly(Vector3DataList obj)
  {
    num = Random.Range(0, obj.vector3List.Count);
    Instantiate(prefab, obj.vector3List[num].value, quaternion.identity);
  }
}
