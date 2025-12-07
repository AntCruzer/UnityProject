using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rock;
    public float spawnRate = 2;
    public float timer = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnRock();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnRock();
            timer = 0;
        }

    }

    void spawnRock()
    {
        Instantiate(rock, transform.position, transform.rotation);
    }
}