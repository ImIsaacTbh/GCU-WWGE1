using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;
using MEC;
using Unity.VisualScripting;
using UnityEngine;

public class Jim : MonoBehaviour
{
    public GameObject SOOP;

    public GameObject bill;

    public float modifier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Timing.RunCoroutine(turret());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator<float> turret()
    {
        while (true)
        {
            if (Vector3.Distance(this.transform.position, bill.transform.position) < 200)
            {
                GameObject projectile = Instantiate(SOOP);
                projectile.SetActive(true);
                projectile.transform.position = this.transform.position;
                projectile.transform.rotation = this.transform.rotation;
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.up * 1000f * Random.Range(0f, 3f));
            }

            yield return Timing.WaitForSeconds(1);
        }
    }
}
