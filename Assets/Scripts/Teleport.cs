using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Image imgTeleport;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private Ray ray;
    [SerializeField] private RaycastHit _hit;

    //Переменные подбора.
    float distance = 3f;
    public Transform pos;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
     if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgTeleport.fillAmount = gvrTimer/totalTime;
        }
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            //А это работает
            if (imgTeleport.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Move>().TeleportRig();
            }

            else if (imgTeleport.fillAmount == 1 && _hit.transform.CompareTag("IceCream"))
            {
                _hit.transform.gameObject.GetComponent<Move>().TeleportObj();
            }
        }

        DrawRay();
    }
    private void DrawRay()
    {
        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            Debug.DrawRay(ray.origin, ray.direction * distanceOfRay, Color.black);
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVRoff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgTeleport.fillAmount = 0;
    }
}
