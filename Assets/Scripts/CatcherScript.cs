using UnityEngine;


public class CatcherScript : MonoBehaviour
{
    [SerializeField] private float catcherSpeed;
    public Sprite[] tableSprite = new Sprite[3];
    int currentCatcherColor = 0;
    SpriteRenderer sr;
    GameObject gameManager;
    public GameObject bubbleFX,gameOverFX;
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        sr=GetComponent<SpriteRenderer>();
        sr.sprite = tableSprite[currentCatcherColor];
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        catcherMov();
        colorChange();

    }

    void catcherMov()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * catcherSpeed * Time.deltaTime);
    }
    void colorChange()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentCatcherColor=(currentCatcherColor + 1) % tableSprite.Length;
            sr.sprite=tableSprite[currentCatcherColor];
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ballScript otherBall=other.GetComponent<ballScript>();
        if (otherBall != null && otherBall.RandomColor == this.currentCatcherColor)
        {
            Debug.Log("Renkler eþleþti");
            gameManager.GetComponent<gameManagerScript>().addScore(1);
            Destroy(other.gameObject);
            GameObject fxModule= Instantiate(bubbleFX, other.transform.position, Quaternion.identity);
            Destroy(fxModule, 2);
        }
        else
        {
            Debug.Log("Game Over");
            gameManager.GetComponent<gameManagerScript>().gameOver();
            Instantiate(gameOverFX, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject,0.05f);
            

        }
    }

}
