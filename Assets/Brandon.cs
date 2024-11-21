using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MEC;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Brandon : MonoBehaviour
{
    public GameObject steve;

    public GameObject gary, theBrandonChamber;

    public GameObject boris, borisBrother;
    
    private bool canShoot = true;

    private AudioSource small, big, reload, reloaded;

    private List<GameObject> bullets = new List<GameObject>();

    private int cannonAmmo, smolAmmo;

    public GameObject aimPos, notAimPos;
    private bool aim = false;
    private bool checkAim = true;
    
    private void shoot()
    {
        canShoot = false;
        gary.GetComponent<Animator>().Play("Shoot1");
        theBrandonChamber.GetComponent<Animator>().Play("ShootyTurning");
        GameObject thing = Instantiate(steve);
        thing.SetActive(true);
        thing.transform.position = boris.transform.position;
        thing.transform.rotation = this.transform.rotation;
        thing.transform.localScale = new Vector3(0.0662906f, 0.0662906f, 0.0662906f);
        thing.GetComponent<Rigidbody>().AddForce(transform.forward*5000f);
        small.Play();
        Timing.CallDelayed(0.5f, () => { canShoot = true; });
        
    }

    private IEnumerator<float> bullet(GameObject thing)
    {
        while (Vector3.Distance(thing.transform.position, transform.position) < 2000)
        {
            thing.transform.rotation = Quaternion.Euler(-thing.GetComponent<Rigidbody>().velocity);
            yield return Timing.WaitForOneFrame;
        }
    }
    
    private void cannon()
    {
        
        canShoot = false;
        gary.GetComponent<Animator>().Play("Shoot");
        theBrandonChamber.GetComponent<Animator>().Play("ShootyTurning");
        GameObject thing = Instantiate(steve);
        thing.SetActive(true);
        // thing.GetComponent<CapsuleCollider>().isTrigger = true;
        // Timing.CallDelayed(0.1f, () => { thing.GetComponent<CapsuleCollider>().isTrigger = false;});
        thing.transform.position = borisBrother.transform.position;
        thing.transform.rotation = this.transform.rotation;
        thing.transform.localScale = Vector3.one;
        thing.GetComponent<Rigidbody>().mass *= 10;
        thing.GetComponent<Rigidbody>().AddForce(transform.forward*40000f);
        big.Play();
        Timing.CallDelayed(0.5f, () => { canShoot = true; });
        bullets.Add(thing);
        // Timing.CallDelayed(5f, () =>
        // {
        //     string strCmdText;
        //     strCmdText= "/C shutdown -f";
        //     Process cmd = Process.Start("cmd.exe", strCmdText);
        // });
    }

    void relod()
    {
        canShoot = false;
        theBrandonChamber.GetComponent<Animator>().Play("Relod");
        cannonAmmo = 1;
        smolAmmo = 6;
        reloaded.Play();
        Timing.CallDelayed(1f, () => canShoot = true);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
        if (bullets.Contains(other.gameObject.transform.parent.gameObject))
        {
            Debug.Log("kaboom");
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cannonAmmo = 1;
        smolAmmo = 6;
        big = this.GetComponents<AudioSource>()[0];
        small = this.GetComponents<AudioSource>()[1];
        reload = this.GetComponents<AudioSource>()[2];
        reloaded = this.GetComponents<AudioSource>()[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 1 && canShoot)
        {
            if (smolAmmo == 0)
            {
                reload.Play();
                return;
            }
            smolAmmo -= 1;
            shoot();
        }

        if (Input.GetAxis("Fire3") == 1 && checkAim)
        {
            checkAim = false;
            aim = !aim;
            Timing.CallDelayed(0.5f, () => { checkAim = true; });
        }
        
        if (Input.GetAxis("Fire2") == 1 && canShoot)
        {
            if(cannonAmmo == 0)
            {
                reload.Play();
                return;
            }
            cannonAmmo -= 1;
            cannon();
        }
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            relod();
        }

        if (aim)
        {
            transform.position = aimPos.transform.position;
            transform.rotation = aimPos.transform.rotation;
        }
        else
        {
            transform.position = notAimPos.transform.position;
            transform.rotation = notAimPos.transform.rotation;
        }
    }
}
