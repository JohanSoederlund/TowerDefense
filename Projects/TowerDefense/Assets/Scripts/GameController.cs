using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private int levelIndex = 0;
    private bool gameRunning = true;
    private GameObject gameOver, victory;
    public GUIText goldText, levelText;
    private int gold;
	// Use this for initialization
	void Start () {
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.SetActive(false);
        victory = GameObject.FindGameObjectWithTag("Victory");
        victory.SetActive(false);
        gold = 80;
        goldText.text = "GOLD     " + gold;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!gameRunning && Input.GetKeyDown("r"))
        {
            Scene level = SceneManager.GetActiveScene();
            SceneManager.LoadScene(level.name);
        } else if (!gameRunning && Input.GetKeyDown("q"))
        {
            Application.Quit();
        }
        
	}
    public bool InstantiatePossibleControl(int cost, string name)
    {
        if (cost <= gold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Purchase(int cost)
    {
        gold -= cost;
        goldText.text = "GOLD     " + gold;
    }
    public void GainGold(int amount)
    {
        gold += amount;
        goldText.text = "GOLD     " + gold;
    }
    public void GameWon()
    {
        victory.SetActive(true);
        gameRunning = false;
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        Destroy(victory);
        gameRunning = false;
    }
    public void setLevel()
    {
        levelIndex++;
        levelText.text = "Level " + levelIndex;
    }
    public int getLevel()
    {
        return levelIndex;
    }

}
