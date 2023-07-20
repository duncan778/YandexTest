using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] View view;
    [SerializeField] GameObject squarePrefab;
    [SerializeField] GameObject yellowPrefab;
    [SerializeField] Player player;
    [SerializeField] int squareNumbers = 3;
    private bool gameNotStarted = true;
 
    private void Awake() 
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (gameNotStarted && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            view.ShowHint(false);
            player.Init(view);
            GenerateSquares();
            gameNotStarted = false;
        }
    }

    private void GenerateSquares()
    {
        for (int i = 0; i < squareNumbers + 1; i++)
        {
            float posX = UnityEngine.Random.Range(20f, 60f);
            float posY = UnityEngine.Random.Range(-4.5f, 4.5f);
            if (i < squareNumbers)
                Instantiate(squarePrefab, new Vector3(posX, posY, 0f), squarePrefab.transform.rotation);
            else
                Instantiate(yellowPrefab, new Vector3(posX, posY, 0f), yellowPrefab.transform.rotation)
                    .GetComponent<Yellow>().Init(player);
        }
    }

}
