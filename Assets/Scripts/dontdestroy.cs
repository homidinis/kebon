using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    private static GameObject _instance;
    // Start is called before the first frame update
    void Start()
    {
        if (!_instance)
        {
            _instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
