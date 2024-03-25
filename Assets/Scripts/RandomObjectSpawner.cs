using System.Collections;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public GameObject[] obstacles;
    private int index = 0;
    void Awake()
    {
        SpawnObstacles();
    }
    public void SpawnObstacles()
    {
        StartCoroutine(GenCoRoutine());
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0 ,0.5f);
        Gizmos.DrawCube(center, size);
    }
    private IEnumerator GenCoRoutine()
    {
        yield return new WaitForSeconds(1f);
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(obstacles[index], pos, Quaternion.identity);
        index++;
        if (index == obstacles.Length)
        {
            index = 0;
        }
        StartCoroutine(GenCoRoutine());
    }
}
