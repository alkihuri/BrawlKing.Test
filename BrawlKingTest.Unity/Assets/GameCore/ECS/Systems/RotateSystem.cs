using Leopotam.Ecs;

public class RotateSystem : IEcsRunSystem
{

    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ObjectDataComponent, RotateDirectionComponent> rotateFilter = null;
    public void Run()
    {
        foreach (var i in rotateFilter)
        {

            var transform = rotateFilter.Get1(i).Player.transform;
            var direction = rotateFilter.Get2(i).RotateDirection;

            transform.Rotate(direction);
        }
    }
}