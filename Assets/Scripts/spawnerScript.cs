using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject ball;
    private float timer;
    [SerializeField] private float spawnRate=2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer<spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            float spawnPoint = 7.5f;
            Instantiate(ball, new Vector3(Random.Range(-spawnPoint,spawnPoint),7f,0), transform.rotation);
            timer = 0;
            
        }
    }
}
