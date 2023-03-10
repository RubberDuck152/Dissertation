using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public float CooldownTime;
    public bool canSpawn;
    public bool Activate;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Camera camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public GameObject player;
    public GameObject teleportSphere;
    public float maxRayDistance;
    [SerializeField] LayerMask layerCheck;

    void Update()
    {
        if (Activate)
        {
            if (canSpawn == true)
            {
                if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, maxRayDistance, layerCheck))
                {
                    Debug.Log("Hit Something");
                    Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
                    teleportSphere.SetActive(true);
                    teleportSphere.transform.position = hitinfo.point;

                    if (Input.GetMouseButton(0))
                    {
                        Debug.Log("Teleporting");
                        player.transform.position = teleportSphere.transform.position;
                        teleportSphere.SetActive(false);
                        canSpawn = false;
                        StartCoroutine(CooldownTimer());
                    }
                }
                else
                {
                    Debug.Log("Missed");
                    Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
                    teleportSphere.SetActive(false);
                }
            }
        }
        else
        {
            canSpawn = true;
        }
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
        Activate = false;
    }
}
