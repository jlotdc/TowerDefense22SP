using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameManagerSO gameManager;
    [SerializeField] EventManagerSO eventManager;

    [SerializeField] Tilemap groundTiles;
    [SerializeField] LayerMask groundLayers;

    [SerializeField] Tower towerToSpawn;
    Tower towerIndicatorObject;
    
    Vector3 mousePosition;
    bool isActive;

    Vector3Int cellPosition;


    private void OnEnable()
    {
        eventManager.onStartPlacingTower += ActiveTowerPlacement;
    }

    private void OnDisable()
    {
        eventManager.onStartPlacingTower -= ActiveTowerPlacement;
    }


    private void Start()
    {
        isActive = false;
    }

    private void Update()
    {

        if (!isActive) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {


                if (gameManager.money >= towerToSpawn.Price)

                {
                    towerIndicatorObject = Instantiate(towerToSpawn, mousePosition, Quaternion.identity);
                    isActive = true;
                    return;
                }
            }
        }


        //allow player to place the tower
        if (isActive)
        {
            GetMousePosition(); //first update the mouse position in game world

            towerIndicatorObject.transform.position = mousePosition; //next, update the indicator object position to the mouse position

            //listen for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                //place down the tower
                //gameManager.money -= towerToSpawn.Price;
                eventManager.ReduceMoney(towerIndicatorObject.Price);
                towerIndicatorObject.ActivateTower();
                towerIndicatorObject = null; //leave tower behind
                isActive = false;           //disable laser poitner
            }

            if (Input.GetMouseButtonDown (1) || Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(towerIndicatorObject.gameObject);
                isActive = false;
            }
        }    
    }


    private void GetMousePosition()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200f, groundLayers))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.yellow);
            
            //mousePosition = hit.point; //update mouse position

            cellPosition = groundTiles.LocalToCell(hit.point); //get the nearest tile/cell

            mousePosition = new Vector3(cellPosition.x + groundTiles.cellSize.x / 2f, 0, cellPosition.y + groundTiles.cellSize.y / 2f); 
        }


    }

    private void ActiveTowerPlacement()
    {
        if (!isActive)
        {

            if (gameManager.money >= towerToSpawn.Price)

            {
                towerIndicatorObject = Instantiate(towerToSpawn, mousePosition, Quaternion.identity);
                isActive = true;
                return;
            }

        }
    }
}
