using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image lifeImage;
    public int score;
    public int maxScore;
    public Text scoreText;
    public Text maxScoreText;

    //objects UI
    [SerializeField]
    private GameObject _lives;
    [SerializeField]
    private GameObject _score;
    [SerializeField]
    private GameObject _titleScreen, _maxScore;
    private GameControl gameControl;

    private void Start()
    {
        score = 0;
        gameControl = GameObject.Find("GameManager").GetComponent<GameControl>();
    }


    public void UpdateLives(int currentLives)
    {
        lifeImage.sprite = lives[currentLives];   
    }
    
    public void UpdateScore()
    {
        score += 10;
        
        scoreText.text = "Score: " + score;

        if (maxScore < score)
        {
            maxScore = score;
            maxScoreText.text = "Max Score: " + maxScore;
        }

    }

    public void DeductScore()
    {
        score -= 10;
        scoreText.text = "Score: " + score;
    }


    public void ShowUI()
    {
        _lives.SetActive(true);
        _score.SetActive(true);
        _titleScreen.SetActive(false);
    }

    public void HideUI()
    {
        _lives.SetActive(false);
        _score.SetActive(false);
        _titleScreen.SetActive(true);
        scoreText.text = "Score: ";
        score = 0;
    }


}
