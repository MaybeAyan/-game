using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberContronller : MonoBehaviour
{
    public static DamageNumberContronller Instance;

    public DamagerNumber numberToSpawn;
    public Transform numberCanvas;

    private List<DamagerNumber> numberPool = new List<DamagerNumber>();

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnDamage(float damageAmount,Vector2 location) 
    {
        int rounded = Mathf.RoundToInt(damageAmount);

        //DamagerNumber newDamage =  Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);

        DamagerNumber newDamage = GetFromPool();

        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);
        newDamage.transform.position = location;
    }

    /**从对象池取出实例*/
    public DamagerNumber GetFromPool() 
    {
        DamagerNumber numberToOutput = null;


        if (numberPool.Count == 0)
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        } else 
        {
            numberToOutput = numberPool[0];
            numberPool.RemoveAt(0);
        }

        return numberToOutput;
    }

    /**放入对象池*/
    public void PlaceInPool(DamagerNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);
        numberPool.Add(numberToPlace);
    }
}

