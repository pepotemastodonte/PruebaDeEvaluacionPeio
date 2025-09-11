using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        text.gameObject.SetActive(true);
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return new  WaitForSeconds(.75f);
        SceneManager.LoadScene("Prueba Avrix");
    }
}
