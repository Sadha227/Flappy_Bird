using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float timeToSpawner = 1f;
    [SerializeField] GameObject pipe;
    [SerializeField] float height;

    private Coroutine spawnerPipesCoroutine;

    IEnumerator Start()
    {
        while (true)
        {
            GameObject newpipe = Instantiate(pipe);
            Vector3 randFactor = new Vector3(0, Random.Range(-height, height), 0);
            newpipe.transform.position = transform.position + randFactor;
            Destroy(newpipe, 5f); // 5f - Время до уничтожения // объекта-трубы (5с)
            yield return new WaitForSeconds(timeToSpawner);
        }
    }


    void Update()
    {
        
    }
}