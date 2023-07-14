using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowShader : MonoBehaviour
{
    public Transform spawnPoint;
    public Material glowMaterial;

    void Update()
    {
        // Set the _WorldSpaceSpawnPoint property of the material to the position of the spawn point
        glowMaterial.SetVector("_WorldSpaceSpawnPoint", spawnPoint.position);
    }
}
