using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TriggerScript2 : MonoBehaviour
{
    public Rigidbody rbResult;
    public TextMeshProUGUI iceCreamText;
    public int iceCreamScore = 0;

    void OnTriggerEnter(Collider other)
    {
        //gameObject.tag = "Player";
        if (other.tag == "IceCream")
        {
            rbResult.GetComponent<Renderer>().material.color = Color.green;
            if (iceCreamScore != null && iceCreamText != null)
            {
                iceCreamScore++;
                iceCreamText.text = "Мороженное: " + iceCreamScore.ToString();
            }
            if (SceneManager.GetActiveScene().name == "Scene2")
            {
                StartCoroutine(YouWin());
            }
        }
        else if (other.tag == "Milk")
        {
            rbResult.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(RestartGame());

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
