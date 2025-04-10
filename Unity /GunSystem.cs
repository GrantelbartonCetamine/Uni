using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resources : https://www.youtube.com/watch?v=bqNW08Tac0Y&list=PLrMEhC9sAD1ya9RFdnjFUL1foVlZjRkE7&index=5
public class GunSystem :  Bullet
{
    [Header("GunStats")]
    public int Damage;
    public float TimeBetweenShootings, Spread, Range, ReloadTime, TimeBetweenShots;
    public int MagaZineSize, BulletPertap;
    public bool HoldButton;
    public int BulletsLeft , BulletsShot ;

    [Header("Bools")]
    private bool Shoot, ReadyToShooting , Reloading;

    [Header("Refs")]
    public Camera FpsvCamera;
    public Transform Attackpoint;
    public RaycastHit RayHit;
    public LayerMask PlayerLayer;
    public Rigidbody PlayerRb;
    private Vector3 direction;

    [Header("Cmomponents")]
    private Player3dControlls PlayerControll;
    private Bullet BulletScript;
    public GameObject BulletPrefab;

    [Header("BulletStats")]
    public float ShootSpeed;
    public float GravityForce;
    public float BulletLifeTime;

    //[Header("Graphic")]
    //public GameObject MuzzleFlash, BulletHoleGraphic;

    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerControll = new Player3dControlls();
    }

    private void Start()
    {
        Shoot = true;
        BulletsLeft = MagaZineSize;
        ReadyToShooting = true;    
    }

    void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        if (PlayerControll.ShootingMap.ShootActions.WasPressedThisFrame() && ReadyToShooting && Shoot && !Reloading && BulletsLeft > 0)
        {
            BulletsShot = BulletPertap;
            Shooting();
        }

        TriggerReload();
    }

    private void TriggerReload() 
    {
        if (Input.GetKeyDown(KeyCode.R) && BulletsLeft < MagaZineSize && !Reloading)
        {
            Reload();
        }
    }
    private void Shooting()
    {
        ReadyToShooting = false;

        float x = Random.Range(-Spread, Spread);
        float y = Random.Range(-Spread, Spread);

        direction = FpsvCamera.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(FpsvCamera.transform.position, direction, out RayHit, Range, PlayerLayer))
        {
            Debug.Log("Hit : " +  RayHit.collider.name);

        }

        if (BulletsShot > 0 && BulletsLeft > 0)
            Invoke("Shooting", TimeBetweenShots);

        Invoke("ResetShoot", TimeBetweenShootings);


        //if (PlayerRb.velocity.magnitude > 0)
        //{
        //    Spread = Spread * 10f;
        //}
        //else
        //{
        //    Spread = Spread * 1;
        //}

        BulletsLeft--; 
        BulletsShot--;
    }

    private void ShootBullet()
    {

    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, ShootPoint.position , ShootPoint.rotation);
        BulletScript bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript)
        {
            bulletScript.Initialize(ShootPoint, ShootSpeed, GravityForce);
            Destroy(bullet , BulletLifeTime);
        }
    }

    private void ResetShoot()
    {
        ReadyToShooting = true;
    }

    private void Reload()
    {
        Reloading = true;
        Invoke("ReloadFinish", ReloadTime);
    }

    private void ReloadFinish()
    {
        BulletsLeft = MagaZineSize;
        Reloading = false;  
    }

    private void OnEnable()
    {
        PlayerControll.Enable();
    }
    private void OnDisable()
    {
        PlayerControll.Disable();
    }

}
