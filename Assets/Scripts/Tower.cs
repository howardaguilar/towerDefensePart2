using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<Enemy> CurrentEnemies;
    public Enemy currentTarget;

    /*
    void OnDrawGizomos()
    {
        Gizmos.DrawWireSphere(GetComponent<SphereCollider>().center, GetComponent<SphereCollider>().radius);
    }*/

    public void OnTriggerEnter(Collider other)
    {
        Enemy newEnemy = other.GetComponent<Enemy>();
        CurrentEnemies.Add(newEnemy);
        //newEnemy.DeathEvent.AddListener(delegate { BookKeeping(newEnemy); });
        EvaluateTarget(newEnemy);
        

        Debug.Log(other.name + " has entered");
    }

    public void OnTriggerExit(Collider other)
    {
        Enemy enemyLeaving = other.GetComponent<Enemy>();

        //enemyLeaving.DeathEvent.RemoveListener(delegate { BookKeeping(enemyLeaving);}); // Un-subscribing to the DeathEvent for this enemy .... don't care anymore // Likely doesn't work!

        CurrentEnemies.Remove(enemyLeaving); // Clean up book
        EvaluateTarget(enemyLeaving);
        
    }

    private void BookKeeping(Enemy enemy)
    {
        CurrentEnemies.Remove(enemy);
        EvaluateTarget(enemy);
    }

    private void EvaluateTarget(Enemy enemy)
    {
        if (currentTarget == enemy)
        {
            currentTarget = null;
        }


        if (currentTarget == null)
        {
            currentTarget = CurrentEnemies[0];
        }
    }
}
