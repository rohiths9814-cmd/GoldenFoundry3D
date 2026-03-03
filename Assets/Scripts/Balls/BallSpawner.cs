using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public BallPool pool;
    public Transform spawnArea;
    public int spawnAmount = 100;

    IEnumerator Start()
    {
        while (!pool.IsReady)
            yield return null;

        SpawnBalls();
    }

    void SpawnBalls()
{
    BoxCollider area = spawnArea.GetComponent<BoxCollider>();

    for (int i = 0; i < spawnAmount; i++)
    {
        GameObject ball = pool.GetBall();
        if (ball != null)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-area.size.x / 2, area.size.x / 2),
                1.5f,
                Random.Range(-area.size.z / 2, area.size.z / 2)
            );

            ball.transform.position = spawnArea.position + randomPos;
        }
    }
    Debug.Log("Ball Spawned");
}
}