using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Player player;
    public float enemyRadius;

    List<Enemy> enemies;

    GameManager gm;
    GameSettings gs;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gs = FindObjectOfType<GameSettings>();

        InitCharacters();
    }

    public void InitCharacters()
    {
        enemies = new List<Enemy>();
        int enemyCount = gs.GetEnemyCount();
        for (int i = 0; i < enemyCount; i++) {
            enemies.Add(CreateEnemy());
        }

        player.SetTarget(GetNearestEnemy());
    }
    
    Enemy CreateEnemy()
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Cos(angle) * Random.Range(2f, enemyRadius); 
        float y = Mathf.Sin(angle) * Random.Range(2f, enemyRadius); 
        Vector3 position = new Vector3(x, 1.5f, y);

        Enemy newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity).GetComponent<Enemy>();
        newEnemy.SetTarget(player.transform);
        return newEnemy;
    }

    public void OnPlayerDeath()
    {
        foreach(Enemy enemy in enemies) {
            enemy.SetTarget(null);
        }
        Destroy(player.gameObject);

        gm.OnGameOver();
    }

    public void OnEmenyDeath(Enemy enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy.gameObject);
        if (enemies.Count > 0) {
            player.SetTarget(GetNearestEnemy());
        } else {
            gm.OnWin();
        }
    }

    public Transform GetNearestEnemy()
    {
        Transform nearestEnemy = null;
        float minDistantion = float.MaxValue;

        foreach (Enemy enemy in enemies) {
            float distantion = (enemy.transform.position - player.transform.position).magnitude;
            if (distantion < minDistantion) {
                nearestEnemy = enemy.transform;
                minDistantion = distantion;
            }
        }

        return nearestEnemy;
    }

}
