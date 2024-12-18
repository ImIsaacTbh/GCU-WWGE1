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
    public GameObject mainPlayer;
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
    
    //This is the small bullet shooting method
    private void shoot()
    {
        canShoot = false;
        gary.GetComponent<Animator>().Play("Shoot1");
        //This is the barrel spin
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
    
    //This is the HUGE bullets, it's the same 44mag but scaled up a lot
    private void cannon()
    {
        //starts the delay stopping you from shooting a revolver like an anti-material cannon
        canShoot = false;
        gary.GetComponent<Animator>().Play("Shoot");
        theBrandonChamber.GetComponent<Animator>().Play("ShootyTurning");
        GameObject thing = Instantiate(steve);
        thing.SetActive(true);
        thing.transform.position = borisBrother.transform.position;
        thing.transform.rotation = this.transform.rotation;
        thing.transform.localScale = Vector3.one;
        thing.GetComponent<Rigidbody>().mass *= 10;
        thing.GetComponent<Rigidbody>().AddForce(transform.forward*40000f);
        big.Play();
        Timing.CallDelayed(0.5f, () => { canShoot = true; });
        bullets.Add(thing);
    }

    //this just plays a dumb animation and sets the ammo counts. also plays the windows 10 notif noise lmao
    void relod()
    {
        canShoot = false;
        theBrandonChamber.GetComponent<Animator>().Play("Relod");
        cannonAmmo = 1;
        smolAmmo = 6;
        reloaded.Play();
        Timing.CallDelayed(1f, () => canShoot = true);
    }
    
    //deletes the small bullets on impact (a bit temperamental)
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
        if (bullets.Contains(other.gameObject.transform.parent.gameObject))
        {
            Debug.Log("kaboom");
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
    
    //assigns the sound clips and sets the initial ammo
    void Start()
    {
        cannonAmmo = 1;
        smolAmmo = 6;
        big = this.GetComponents<AudioSource>()[0];
        small = this.GetComponents<AudioSource>()[1];
        reload = this.GetComponents<AudioSource>()[2];
        reloaded = this.GetComponents<AudioSource>()[3];
    }

    //handles inputs and basic logic
    void Update()
    {
        if (mainPlayer.GetComponent<Bill>().stop) return;
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
