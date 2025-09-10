using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private float maxHealth;
    public int count;
    private float timeCount;
    private int time;

    public bool canContinue;

    public Image image;
    public Image menuImage;
    public Text countText;
    public Text timeText;
    public Button playbutton;

    PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        canContinue = false;

        countText.text = "0";

        playerMovement = FindAnyObjectByType<PlayerMovement>();

        maxHealth = playerMovement.healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Time.timeScale = 0f; 
            canContinue = false;
        }
 
        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            Time.timeScale = 1f;
            canContinue = true;
        }


        timeCount += Time.deltaTime;

        if(timeCount >= 1)
        {
            time++;
            timeCount = 0;
        }

        image.fillAmount = playerMovement.healthPoints / maxHealth;

        countText.text = count.ToString();
        timeText.text = time.ToString();
    }

    public void StartGame()
    {
        menuImage.GetComponent<Image>().enabled = false;
        playbutton.gameObject.SetActive(false);
        Time.timeScale = 1f;
        canContinue = true;
    }

}
