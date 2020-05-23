using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject meteor;
    
    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            //Instantiate(meteor, this.transform.position +
            //new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);

            GameObject _meteor = Pool.singleton.Get("meteor");
            if(_meteor != null)
            {
                _meteor.transform.position = this.transform.position +
                                                new Vector3(Random.Range(-8, 8), 0, 0);
                _meteor.SetActive(true);
            }
        }       
        
    }
}
