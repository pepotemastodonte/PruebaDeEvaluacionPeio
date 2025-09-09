using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameEnding()
    {
        image.GetComponent<Image>().enabled = true;
        text.enabled = true;
    }
}
