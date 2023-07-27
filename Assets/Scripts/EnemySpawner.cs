using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private GameObject boss;
    private float[] xPoses = { -2.2f, -1.1f, 0, 1.1f, 2.2f };
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private int level = 1;
    private int spawnCount = 0;
    [SerializeField]
    private int levelUpStandard = 5;
    private bool speedUp = false;
    [SerializeField]
    private float moveSpeed = 5f;
    void Start()
    {
        StartCoroutine("EnemyRoutine");
    }

    public void stopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }
    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        int nowEnemy;
        while (true)
        {
            nowEnemy = level / 3;
            spawnCount++;
            if (spawnCount % levelUpStandard == 0)
            {
                level++;
                if (nowEnemy == enemies.Length - 1) speedUp = true;
                if (speedUp)
                {
                    moveSpeed += 2f;
                }
            }
            foreach(float xPos in xPoses)
            {
                int enemyLevel = enemyLevelFnc(nowEnemy, level);
                if (enemyLevel > enemies.Length - 1) enemyLevel = enemies.Length - 1;
                createEnemy(xPos, enemyLevel);
            }
            if (level > 21)
            {
                createBoss();
                level = 1;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void createBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
    void createEnemy(float xPos, int idx)
    {
        GameObject enemyOb = Instantiate(enemies[idx], 
            new Vector3(xPos, transform.position.y, transform.position.z), 
            Quaternion.identity);
        Enemy enemy = enemyOb.GetComponent<Enemy>();
        enemy.setMoveSpeed(moveSpeed);
    }

    int enemyLevelFnc(int nowEnemy, int level)
    {
        if (nowEnemy >= enemies.Length-1) return enemies.Length-1;
        if (level % 3 == 1)
        {
            return nowEnemy;
        }
        else if(level % 3 == 2)
        {
            float tmp = Random.Range(0, 100);
            if (tmp < 60)
            {
                return nowEnemy;
            }
            else
            {
                return nowEnemy + 1;
            }
        }
        else
        {
            float tmp = Random.Range(0, 100);
            if (tmp < 30)
            {
                return nowEnemy;
            }
            else if(tmp<70)
            {
                return nowEnemy + 1;
            }
            else
            {
                return nowEnemy + 2;
            }
        }
    }
    
}
