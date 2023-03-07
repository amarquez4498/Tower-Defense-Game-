using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public BaseTower tower;
    public BaseTower[] towers;

    
    public Transform[] waypoints;

    public float maxHeatlh;
    [SerializeField]
    float health;
    public Image healthImage;
    public float lerpSpeed;
    [HideInInspector]
    public float currentTowerCost;
    public float money;
    public Text moneyText;

    public float timeBetweenSpawnLow;
    public float timeBetweenSpawnHigh;
    float cools;

    public GameObject spawnPosition;
    public GameObject[] enemies;

    public bool gameOver;
    public GameObject gameOverUI;

    private void Awake()
    {
        health = maxHeatlh;
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, health / maxHeatlh, lerpSpeed * Time.deltaTime);
        UpdateTower(0);
        gameOver = false;

    }

    public void UpdateTower(int i)
    {
        tower = towers[i];
        currentTowerCost = towers[i].cost;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
                Time.timeScale = 2f;
            if (Input.GetKeyDown(KeyCode.Alpha1))
                Time.timeScale = 1f;
        }

        moneyText.text = "MONEY: " + money.ToString();
        healthImage.fillAmount = health / maxHeatlh;

        if (!gameOver)
        {
            if (cools > 0)
                cools -= Time.deltaTime;
            else
                SpawnEnemy();
        }
        if (gameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition.transform.position, Quaternion.Euler(0, 0, -90));
        cools = Random.Range(timeBetweenSpawnLow, timeBetweenSpawnHigh);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            gameOver = true;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        //healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, health / maxHeatlh, lerpSpeed * Time.deltaTime);
        
    }

    public void GiveMoney(float amount)
    {
        money += amount; 
    }
}
