using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Klasa przechowywująca dane gracza ilośc jego żyć, punkty oraz klucze.
/// Jest statyczna co sprawia że może istanieć tylko jedna instanacja tej klasy, nie jest niszczona podczas załadowania nowej sceny
/// </summary>
public class PermanentUI : MonoBehaviour
{
    /* 
     * singleton patern represent player score and helath
     * data are available anywhere in the program
     */
    public int score;
    public int health;
    public bool redKey=false;
    public bool greenKey=false;
    public TextMeshProUGUI scoreText;

    public static PermanentUI perm;//instance of object

    private void Start()
    {
        DontDestroyOnLoad(gameObject);//dot destroy object when new create new istance of object
        if (!perm)
            perm = this;
        else
            Destroy(gameObject);
    }
    private void Update()//update player score
    {
        scoreText.text = score.ToString();
    }
    public void Reset()//reset playe score
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    /// <summary>
    /// Logika tworzenia pasku zdrowia bossa 
    /// </summary>
    /// <param name="bossHealthBar"> obiekt reprezentujący pasek zdrowia bossa</param>
    public void CreateBossHealthBar(GameObject bossHealthBar)
    {
        GameObject parent_ = GameObject.FindGameObjectWithTag("Health Bar pivot");
        //jak mamy prefab i chcemy dodać do prefaba to musimy stworzyć nową zmienna bo inaczej błąd
        GameObject bar = Instantiate(bossHealthBar, transform.position, Quaternion.identity) as GameObject;
        RectTransform tmp = bar.GetComponent<RectTransform>();
        bar.GetComponent<RectTransform>().SetParent(parent_.GetComponent<RectTransform>());
        bar.GetComponent<Transform>().SetParent(parent_.GetComponent<RectTransform>());
    }
    /// <summary>
    /// zniszcznie pasku zdrowia bossa
    /// </summary>
    /// <param name="bossHealthBar"> pasek zdrowia do zniszczenia </param>
    public void DestroyBossHealthBar(GameObject bossHealthBar)
    {
        Destroy(GameObject.FindGameObjectWithTag("Health Bar"));
    }
    /// <summary>
    /// zniszcznie  UI
    /// </summary>
    public void DestroyUI()
    {
        perm = null;
        Destroy(gameObject);
    }
}
