using UnityEngine;

public class ballScript : MonoBehaviour
{
    public Sprite[] ballSprite = new Sprite[3];
    SpriteRenderer br;
    public int RandomColor=3;
    void Awake()
    {
        br = GetComponent<SpriteRenderer>();
        BallColorRange();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-10.5f)
        {
            Destroy(gameObject);
        }
    }

    void BallColorRange()
    {
        RandomColor=Random.Range(0, ballSprite.Length);
        br.sprite = ballSprite[RandomColor];
        
    }

    
}
