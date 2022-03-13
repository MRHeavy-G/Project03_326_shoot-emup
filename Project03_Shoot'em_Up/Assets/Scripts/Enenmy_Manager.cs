using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enenmy_Manager : MonoBehaviour
{

    public Enemy[] prefabs;

    public int rows = 4;
    public int columns = 6;

    private Vector3 direction = Vector2.right;

    public AnimationCurve speed;

    public int amountKilled { get; private set; }

    public int totalEnemys => this.rows * this.columns;

    public float percentKilled => (float) this.amountKilled / (float) this.totalEnemys;

    public float misAttackRate = 5.0f;

    public int amountAlive => totalEnemys - amountKilled;

    public Projectile missilePrefab;

    public System.Action<Enemy> killed;

    public Vector3 initialPosition { get; private set; }


    /**
     * This method will create the needed enemies in the rows and colmuns with distinct enemies added in before the game runs.
     */
    public void Awake()
    {
        initialPosition = transform.position;

        for (int i = 0; i < rows;i++)
        {
            float w = 0.9f * (columns - 1);
            float h = 0.9f * (rows - 1);
            Vector2 center = new Vector2(-w /2, -h/2);
            Vector3 rowPos = new Vector3(center.x , center.y +(i * 0.9f), 0.0f); 

            for (int j = 0; j < columns;j++)
            {
                Enemy e = Instantiate(prefabs[i], transform);
                e.killed += OnEnemyKilled;
                //e.killed += EnemyKilled;
                //Debug.Log("In");
                Vector3 pos = rowPos;
                pos.x += j * 0.9f;
                e.transform.localPosition = pos;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissleAttack),misAttackRate,misAttackRate);
    }

    /**
     * This update method will allow the enemies to move along a line and then shift down as needed
     * 
     */
    private void Update()
    {
        this.transform.position += direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (direction == Vector3.right && enemy.position.x >= rightEdge.x - 1)
            {
                ChangeDirection();
            } else if (direction == Vector3.left && enemy.position.x <= leftEdge.x + 1)
            {
                ChangeDirection();
            }

        }
    }

    public void MissleAttack()
    {
        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1.0f / (float) amountAlive))
            {
                Instantiate(missilePrefab, enemy.position, Quaternion.identity);
                break;
            }
        }
    }


    private void ChangeDirection()
    {
        direction.x *= -1.0f;

        Vector3 pos = this.transform.position;
        pos.y -= 1.0f;
        this.transform.position = pos;
    }

    /**
    private void EnemyKilled()
    {
        this.amountKilled++;

        if (amountKilled >= totalEnemys)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    */

    private void OnEnemyKilled(Enemy e)
    {
        e.gameObject.SetActive(false);
        amountKilled++;
        killed(e);
    }

    public void ResetEnemy()
    {
        amountKilled = 0;
        direction = Vector3.right;
        transform.position = initialPosition;

        foreach (Transform e in transform)
        {
            e.gameObject.SetActive(true);
        }
    }

}
