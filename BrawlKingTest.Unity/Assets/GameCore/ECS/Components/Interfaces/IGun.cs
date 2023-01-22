


public interface IGun
{
    public float Damage { get; }
    public float Rate { get; }
    public void GunBinding(PlayerDataComponent holder);
    public void DoAttack();

}
