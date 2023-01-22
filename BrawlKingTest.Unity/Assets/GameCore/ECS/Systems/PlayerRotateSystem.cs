using Leopotam.Ecs;
using UnityEngine;
public class PlayerRotateSystem : IEcsInitSystem, IEcsRunSystem
{

    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerDataComponent, RotateDirectionComponent> rotateFilter = null;
    private Camera _camera;

    public void Init()
    {
        _camera = Camera.main;
    }

    public void Run()
    {
        foreach (var i in rotateFilter)
        {


            var transform = rotateFilter.Get1(i).Player.transform;
            var direction = rotateFilter.Get2(i).RotateDirection;
            var worldPosition = transform.position;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 1000))
            {
                 worldPosition = hitData.point;
            }

            transform.LookAt(worldPosition);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}