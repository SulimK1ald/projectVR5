using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript1 : MonoBehaviour
{
    public TextMeshProUGUI milkText;
    public int milkScore = 0;


    public Rigidbody rbResult;
    void OnTriggerEnter(Collider other)
    {
        //gameObject.tag = "Player";
        if (other.tag == "IceCream")
        {
            rbResult.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(RestartGame());
        }
        else if (other.tag == "Milk")
        {
            rbResult.GetComponent<Renderer>().material.color = Color.green;
            milkScore++;
            milkText.text = "Молоко: " + milkScore.ToString();
            if (SceneManager.GetActiveScene().name == "Scene2")
            {
                StartCoroutine(YouWin());
            }

        }
        else if (other.tag == "Eggs")
        {
            rbResult.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(RestartGame());

        }
        IEnumerator RestartGame()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StopCoroutine(RestartGame());
        }
        IEnumerator YouWin()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(1);
            StopCoroutine(YouWin());
        }

    }
}
