using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image lifeImage;
    public int score;
    public Text scoreText;

    //objects UI
    [SerializeField]
    private GameObject _lives;
    [SerializeField]
    private GameObject _score;
    [SerializeField]
    private GameObject _titleScreen;

    private void Start()
    {
        score = 0;
    }

    public void UpdateLives(int currentLives)
    {
        lifeImage.sprite = lives[currentLives];   
    }
    
    public void UpdateScore()
    {
        score += 10;

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
