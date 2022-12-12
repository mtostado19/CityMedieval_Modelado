using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "LightScript", menuName = "CityWalls/LightScript", order = 0)]
public class LightScript : ScriptableObject {
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
}
