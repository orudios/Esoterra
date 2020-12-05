using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class DBResource {
    public string displayName;
    public int ID;
    public int atomicNumber;
    public string symbol;

    [Newtonsoft.Json.JsonConstructor]
    public DBResource(string displayName, int ID, int atomicNumber, string symbol)
    {
        this.displayName = displayName;
        this.ID = ID;
        this.atomicNumber = atomicNumber;
        this.symbol = symbol;
    }
}


public class ResourceDatabase : MonoBehaviour
{
    public static ResourceDatabase Instance { get; set; }

    List<DBResource> ResourceList { get; set; }


    void Start()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
        BuildDatabase();
    }

    public void BuildDatabase()
    {
        ResourceList = JsonConvert.DeserializeObject<List<DBResource>>(UnityEngine.Resources.Load<TextAsset>("JSON/Resources").ToString());
    }

    public string GetDisplayName(int ID)
    {
        foreach (DBResource res in ResourceList) {
            if (res.ID == ID) {
                return res.displayName;
            }
        }
        return "";
    }

    public int GetID(string name)
    {
        foreach (DBResource res in ResourceList) {
            if (res.displayName == name) {
                return res.ID;
            }
        }
        return 0;
    }
}
