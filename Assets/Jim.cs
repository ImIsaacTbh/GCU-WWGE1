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
    
    void Start()
    {
        Timing.RunCoroutine(turret());
    }
    //This points the turret at the player, i didn't bother doing any arc calcs for accuracy on the turret but if i was to this is where it would be.
    //It will shoot directly towards the player so depending on the range it will hit the ground
    public IEnumerator<float> turret()
    {
        while (true)
        {
            if (Vector3.Distance(this.transform.position, bill.transform.position) < 60)
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
