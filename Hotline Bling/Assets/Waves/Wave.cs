using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "New Wave")]
public class Wave : ScriptableObject {

    public string startOfWaveText = "";
    public string endOfWaveText = "";

    public List <EnemyScript> EnemyTypes;
    public float spawnRate = 3f;
    public int enemies = 0;
    



}
