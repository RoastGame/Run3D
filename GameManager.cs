using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float respawnDelay = 2f;
    private bool isGameEnding = false;
    private int score;
    public Text scoreText;
    public GameObject winnerUI;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        if(isGameEnding == false)
        {
            isGameEnding = true;
            StartCoroutine("RespawnCoroutine");
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        playerController.transform.position = playerController.respawnPoint;
        playerController.gameObject.SetActive(true);
        isGameEnding= false;
    }

    public void AddScore(int numberofScore)
    {
        score += numberofScore;
        scoreText.text = score.ToString();
    }

    public void LevelUp()
    {
        winnerUI.SetActive(true);
        Invoke("NextLevel", 2f);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
