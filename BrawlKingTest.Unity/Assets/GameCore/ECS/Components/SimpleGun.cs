
using UnityEngine;

public  class SimpleGun : IGun
{
    private float _damage;
    private float _rate;
    private GameObject _bullet;
    private Rigidbody _bulletPhysic;
    private IGun _gun;

    public SimpleGun(float damage, float rate, GameObject bullet)
    {
        _damage = damage;
        _rate = rate;
        _bullet = bullet;
    }
    public SimpleGun()
    {
        _damage = 1;
        _rate = 1;
        _bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _bullet.SetActive(false);
        _bulletPhysic = _bullet.AddComponent<Rigidbody>();
    }

    public float Damage => _damage;

    public float Rate => _rate;
     

    public void DoAttack()
    {
        _bullet.transform.position = Vector3.zero;
        _bullet.SetActive(true);
        _bulletPhysic.AddForce(_bullet.transform.forward * 100);
    }

    /* no time for this shit 
    public void GunInnit(IGun gun)
    {
        _gun = gun;
    }
    */
}
