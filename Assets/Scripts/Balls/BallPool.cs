using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public GameObject ballPrefab;
    public int poolSize = 500;

    private Queue<GameObject> pool = new Queue<GameObject>();

    public bool IsReady { get; private set; }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab, transform);
            ball.SetActive(false);
            pool.Enqueue(ball);
        }
    
        IsReady = true;
    }

    public GameObject GetBall()
    {
        if (pool.Count > 0)
        {
            GameObject ball = pool.Dequeue();
            ball.SetActive(true);
            return ball;
        }
        return null;
    }

    public void ReturnBall(GameObject ball)
    {
        ball.SetActive(false);
        pool.Enqueue(ball);
    }
}