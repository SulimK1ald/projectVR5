using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCreator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletVelocity = 20f;

    public GameObject[] objs;
    public int random;
    public Text randomText;
    public GameObject objImage1;
    public GameObject objImage2;
    public GameObject objImage3;

    public void Start()
    {
        random = Random.Range(0, objs.Length);
        updateImage();
    }
    public void Shooting()
    {
        if (Time.timeScale == 1)
        {
            updateImage();
            GameObject newBullet = Instantiate(objs[random], transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;
            random = Random.Range(0, objs.Length);
            updateImage();
        }
    }
    public void updateImage()
    {
        if  (random == 0)
        {
            objImage1.SetActive(true);
            objImage2.SetActive(false);
            objImage3.SetActive(false);
        }
        if (random == 1)
        {
            objImage1.SetActive(false);
            objImage2.SetActive(true);
            objImage3.SetActive(false);
        }
        if (random == 2)
        {
            objImage1.SetActive(false);
            objImage2.SetActive(false);
            objImage3.SetActive(true);
        }
    }
}
