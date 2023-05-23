using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int ticker;
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private List<Transform> allCells;

    public static Action<string> slide;

    [SerializeField] private float timeToNextTurn;
    private float currentTimeFromLastTurn;
    private void OnEnable()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;


        StartSpawnFill();
        StartSpawnFill();
    }
    private void Update()
    {
        currentTimeFromLastTurn += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFill();
        }

        if(currentTimeFromLastTurn > timeToNextTurn)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ticker = 0;
                slide("w");
                currentTimeFromLastTurn = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                ticker = 0;
                slide("s");
                currentTimeFromLastTurn = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                ticker = 0;
                slide("a");
                currentTimeFromLastTurn = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                ticker = 0;
                slide("d");
                currentTimeFromLastTurn = 0;
                return;
            }
        }

    }

    public void SpawnFill()
    {
        float chanse = UnityEngine.Random.Range(0f, 1f);
        Transform whichCellToSpawn = allCells[UnityEngine.Random.Range(0, allCells.Count)];

        if(whichCellToSpawn.childCount != 0) 
        {
            SpawnFill();
            return;
        }

        if (chanse < .2f)
        {
            return;
        }
        else if (chanse < .8f)
        {
            GameObject tempFill = Instantiate(fillPrefab, whichCellToSpawn);
            Fill fill = tempFill.GetComponent<Fill>();
            whichCellToSpawn.GetComponent<Cell>().fill = fill;
            fill.changeValue(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, whichCellToSpawn);
            Fill fill = tempFill.GetComponent<Fill>();
            whichCellToSpawn.GetComponent<Cell>().fill = fill;
            fill.changeValue(4);
        }
    }

    public void StartSpawnFill()
    {
        Transform whichCellToSpawn = allCells[UnityEngine.Random.Range(0, allCells.Count)];

        if (whichCellToSpawn.childCount != 0)
        {
            SpawnFill();
            return;
        }

        GameObject tempFill = Instantiate(fillPrefab, whichCellToSpawn);
        Fill fill = tempFill.GetComponent<Fill>();
        whichCellToSpawn.GetComponent<Cell>().fill = fill;
        fill.changeValue(2);
       
    }
}
