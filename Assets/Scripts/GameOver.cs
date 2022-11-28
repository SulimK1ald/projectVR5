using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject deadPanel;

    public float countdown;
    public TextMeshProUGUI timerText;
    public bool stopGame = false;


    private void Start()
    {
        Time.timeScale = 1;
        deadPanel.SetActive(false);
        timerText.text = countdown.ToString();
    }

    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            timerText.text = countdown.ToString();
            timerText.text = Mathf.Round(countdown).ToString();
        }
        else
        {
            stopGame = true;
            Time.timeScale = 0;
            deadPanel.SetActive(true);
            Restart();
        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
        StopCoroutine(Restart());
    }
}
