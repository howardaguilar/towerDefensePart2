using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Group
{
    public GameObject enemyType;
    [Range(0, 50)]public int amountOfEnemies;
    [Range(0, 5)] public float timeDelayBetweenEnemies;

    public Group(GameObject enemyType, int amountOfEnemies, float timeDelayBetweenEnemies)
    {
        this.enemyType = enemyType;
        this.amountOfEnemies = amountOfEnemies;
        this.timeDelayBetweenEnemies = timeDelayBetweenEnemies;
    }
}

[System.Serializable]
public struct Wave
{
    public Group[] enemyGroups;
}

public class EnemyManager : MonoBehaviour
{
    
    // Figure out what enemy wave slook like and how to handle them (e.g. spawning, how many, wait time in between)
    //public GameObject easyEnemy;
    //public GameObject hardEnemy;

    // Pass navigational path to enemies
    public Waypoints[] navPoints;
    public Wave enemyWave;
    //public GameObject easyEnemy;
    //public GameObject hardEnemy;

    private void Start()
    {

        SpawnWave();
    }

    private void SpawnWave()
    {
        foreach(Group group in enemyWave.enemyGroups)
        {
            StartCoroutine(SpawnGroup(group));
            //GameObject spawnedEnemy = Instantiate(group.enemyType);
            //spawnedEnemy.GetComponent<Enemy>().StartEnemy(navPoints);
        }

    }

    IEnumerator SpawnGroup(Group enemyGroup)
    {
        while(enemyGroup.amountOfEnemies > 0)
        {
            GameObject spawnedEnemy = Instantiate(enemyGroup.enemyType);
            spawnedEnemy.GetComponent<Enemy>().StartEnemy(navPoints);
            enemyGroup.amountOfEnemies--;
            yield return new WaitForSeconds(enemyGroup.timeDelayBetweenEnemies);  
        }
    }

}
