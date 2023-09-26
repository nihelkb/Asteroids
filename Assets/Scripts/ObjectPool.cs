using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    
    public List<GameObject> bulletPool;

    public GameObject bulletPrefab;

    public int amountToPool = 5;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();

        // Se inicializan 5 balas al principio del juego
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }

    // Devuelve una bala reciclada
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            GameObject obj = bulletPool[i];
            
            if (obj.activeInHierarchy == false)
            {
                return obj;
            }
        }

        // En caso de no haber balas reciclables, se crean otras 5.
        IncreasePool();
        return GetPooledObject();
    }

    private void IncreasePool()
    {
        for (int j = 0; j < amountToPool; j++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }
}
