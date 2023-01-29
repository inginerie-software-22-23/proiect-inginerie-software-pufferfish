using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /*private static DontDestroy instance = null;
    public static DontDestroy Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != t$$anonymous$$s) {
            Destroy(t$$anonymous$$s.gameObject);
            return;
        } else
        {
            instance = t$$anonymous$$s;
        }
        DontDestroyOnLoad(t$$anonymous$$s.gameObject);
    }*/
}