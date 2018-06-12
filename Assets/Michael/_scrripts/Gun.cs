using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {


	public float damage = 10f;
	public float range = 100f;
	public float bulletForce = 1000f;
	public GameObject ammo;
	public Rigidbody RB;

	[Header("audio")]
	public AudioClip fire;
	public AudioSource bam;

	public int maxAmmo = 1;
	private int currentAmmo;
	public float reloadTime = .5f;
	private bool isReloading = false;

	public GameObject turret;

    public Transform cannonEnd;

	void Start()
	{
		currentAmmo = maxAmmo;
		RB = GetComponent<Rigidbody>();


	}


    private void Update()
    {

		if (isReloading = false) 
		{
			return;
		}

         if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


		if (currentAmmo <= 0)
		{
			StartCoroutine (Reload ());
			return;
		}
    }

    void Shoot()
    {
		if (currentAmmo <= 0)
	{
			return;
	}
		currentAmmo--;
		bam.Play ();
     //   BulletPool.Instance.SpawnFromPool("Boollay", transform.position, Quaternion.identity);
        GameObject bullet = Instantiate (ammo,cannonEnd.transform.position,cannonEnd.transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce (-transform.forward * bulletForce, ForceMode.Impulse);
    }


	IEnumerator Reload()
	{
		isReloading = true;
		yield return new WaitForSeconds (reloadTime);
		currentAmmo = maxAmmo;
		isReloading = false;
	}
}
