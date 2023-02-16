using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private float _spawnMinX;
    [SerializeField] private float _spawnMaxX;
    [SerializeField] private float _spawnMinY;
    [SerializeField] private float _spawnMaxY;
    [SerializeField] private float _spawnMinZ;
    [SerializeField] private float _spawnMaxZ;

    public void SpawnObjects()
    {
        var spawnX = Random.Range(_spawnMinX, _spawnMaxX);
        var spawnY = Random.Range(_spawnMinY, _spawnMaxY);
        var spawnZ = Random.Range(_spawnMinZ, _spawnMaxZ);
        var spawnPosition = new Vector3(spawnX, spawnY, spawnZ);
        int obstaclePrefabIndex = Random.Range(0, _obstaclePrefab.Length);

        Instantiate(_obstaclePrefab[obstaclePrefabIndex], spawnPosition, _obstaclePrefab[obstaclePrefabIndex].transform.rotation);
    }
}
