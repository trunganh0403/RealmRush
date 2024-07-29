using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CarSpawner : ObjSpawner
{
    protected override void ConfigurePrefab()
    {
        prefab = this.RandomPrefab();
        pos = prefab.transform.position;
        rotation = prefab.transform.rotation;
    }
    
}
