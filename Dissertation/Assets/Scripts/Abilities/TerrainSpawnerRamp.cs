using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawnerRamp : MonoBehaviour
{
    public float CooldownTime;
    public float rampDuration;
    public bool canSpawn;
    public bool Activate;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Camera camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public GameObject player;
    public GameObject teleportSphere;
    public GameObject rampObject;
    public GameObject newRampObject;
    public float minDistance;
    public float maxRayDistance;
    [SerializeField] LayerMask layerCheck;

    void Update()
    {
        if (Activate)
        {
            if (canSpawn == true)
            {
                if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, maxRayDistance, layerCheck))
                {
                    Debug.Log("Hit Something");
                    Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
                    if (Vector3.Distance(teleportSphere.transform.position, player.transform.position) > minDistance)
                    {
                        teleportSphere.SetActive(true);
                        teleportSphere.transform.position = hitinfo.point;
                        if (Input.GetMouseButton(0))
                        {
                            newRampObject = Instantiate(rampObject);
                            newRampObject.transform.position = teleportSphere.transform.position + new Vector3(0.0f, newRampObject.transform.localScale.y / 2.0f, 0.0f);
                            teleportSphere.SetActive(false);
                            canSpawn = false;
                            StartCoroutine(CooldownTimer());
                        }
                    }
                    else
                    {
                        teleportSphere.SetActive(false);
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
        yield return new WaitForSeconds(rampDuration);
        Destroy(newRampObject);
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
        Activate = false;
    }
}
