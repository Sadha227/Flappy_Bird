using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float timeToSpawner = 1f;
    [SerializeField] GameObject pipe1;
    [SerializeField] GameObject pipe2;
    [SerializeField] float height;

    private int pipeNum = 0;
    private Coroutine spawnerPipesCoroutine;

    void Start()
    {
       
    }

    IEnumerator SpawenPipe()
    {
        while (true)
        {
            if (pipeNum == 0)
            {
                CreateAndMove(pipe1);

            }
            else if (pipeNum == 1)
            {
                CreateAndMove(pipe2);
            }
            yield return new WaitForSeconds(timeToSpawner);
            pipeNum = 1 - pipeNum;
        }
    }

    public void StartSpawning()
    {
        spawnerPipesCoroutine = StartCoroutine(SpawenPipe());
    }

    private void CreateAndMove(GameObject pipe)
    {
        GameObject newpipe = Instantiate(pipe);
        Vector3 randFactor = new Vector3(0, Random.Range(-height, height), 0);
        newpipe.transform.position = transform.position + randFactor;
        Destroy(newpipe, 5f); // 5f - Время до уничтожения // объекта-трубы (5с)
    }

    void Update()
    {
        
    }
}