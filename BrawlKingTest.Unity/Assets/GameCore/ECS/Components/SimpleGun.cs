using System.Collections;
using UnityEngine;

public class SimpleGun : IGun
{
    private float _damage;
    private float _rate;
    private bool _isReady;
    private GameObject _bullet;
    private BulletController _bulletController;
    private Rigidbody _bulletPhysic;
    private Collider _collider;
    private IGun _gun;
    private PlayerDataComponent _holder;

    public SimpleGun(float damage, float rate, GameObject bullet)
    {
        _damage = damage;
        _rate = rate;
        _bullet = bullet;
    }
    public SimpleGun()
    {
        /// cashing 
        _damage = 50;
        _rate = 3;
        _bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _bullet.tag = "Player";
        _bullet.AddComponent<CollisionHandler>();
        _bullet.SetActive(false);
        _bulletController = _bullet.AddComponent<BulletController>();
        _bulletController.InnitBulet(this);
        _bulletPhysic = _bullet.AddComponent<Rigidbody>();
        _bulletPhysic.useGravity = false;
        _collider = _bullet.GetComponent<Collider>();
        _collider.isTrigger = true;
        IsReady = true;
    }

    public float Damage => _damage;

    public float Rate => _rate;

    public bool IsReady { get => _isReady; set => _isReady = value; }
    public bool Reloading { get; private set; }

    public void DoAttack()
    {

        if (!IsReady)
            return;

        var reloader = Reloader();
        while (reloader.MoveNext()) Reloading = true;

        Reloading = false;

        _bullet.transform.position = _holder.Player.transform.position;
        _bullet.SetActive(true);


        var shootDirection =
            _holder.Player.transform.TransformDirection(Vector3.forward);

        _bulletPhysic.velocity = Vector3.zero;

        _bulletPhysic.AddForce(shootDirection * Damage, ForceMode.Impulse);
    }


    public void GunBinding(PlayerDataComponent holder)
    {
        _holder = holder;
    }


    private IEnumerator Reloader()
    {
        IsReady = false;
        yield return new WaitForSeconds(Rate);
        IsReady = true;
    }
}
