using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1.Find Target
//2.Turn Around
public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;

  [Header("Use Bullets(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

 [Header("Use Laser")]
    public bool useLaser = false;

    public int damageLaser = 20;
    public float slowPct = .5f;

    public LineRenderer linerenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
 
    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearestenemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearestenemy = enemy;
            }
        }
        if (nearestenemy != null && shortesDistance <= range)
        {
            target = nearestenemy.transform;
            targetEnemy = nearestenemy.GetComponent<Enemy>();
        }
        else

            target = null;
    }
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (linerenderer.enabled)
                {
                    linerenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }


        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
        //Quaternion = Unity in döndürme fonksiyonu(rotasyonlarý  belirtmek için de kullanýlýr)
        //Lerp = Yavaþ yavaþ gitmesini saðlar.
        //Euler = z ekseni etrafýnda z derece, x ekseni etrafýnda x derece ve y ekseni etrafýnda y derece döndüren bir dönüþ döndürür; bu sýrayla uygulanýr.      
        //Instantiate = Nesneyi klonlmaya ve döndürmeye yarar.
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }
   
    
    void Laser()
    {
        targetEnemy.TakeDamage(damageLaser * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!linerenderer.enabled)
        {
            linerenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        linerenderer.SetPosition(0, firePoint.position);
        linerenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

    //Düþman olarak iþaretli hedefleri seç. En yakýn olaný bul ve en yakýn olanýn menziln içinde oldup olmadýðýný hatta hedef olup olmadýðýný kontrol et.

//foreach = tüm öðelerde iþlevi çaðýrýr.