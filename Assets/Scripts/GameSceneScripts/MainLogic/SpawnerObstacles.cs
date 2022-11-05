using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerObstacles : MonoBehaviour
{
    private enum Axis { X, Y, Z }

    #region SerializeFields
    [SerializeField] private GameObject Prefab;
    [SerializeField] private int ObstaclesCount;
    [Range(1, 5)]
    [SerializeField] private float TimeBetweenSpawn;
    #endregion

    private Vector3 _spawnPosition;

    private void Start() => InvokeRepeating(nameof(Create), 0, TimeBetweenSpawn);

    #region Methods
    private void Create()
    {
        for (int i = 1; i <= ObstaclesCount; i++)
        {
            _spawnPosition = new Vector3(-6.3f, GetRandomCoords(Axis.Y), GetRandomCoords(Axis.Z));
            Instantiate(Prefab, _spawnPosition, Quaternion.Euler(Vector3.zero));
        }
    }
    private float GetRandomCoords(Axis axis)
    {
        return axis switch
        {
            Axis.Y => Random.Range(15, 30),
            Axis.Z => Random.Range(-1.65f, 1.59f),
            _ => 0,
        };
    }
    #endregion
}