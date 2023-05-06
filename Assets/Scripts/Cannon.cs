using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Gamemanager _gameManager;
    public GameObject characterPrefabs;
    public float currentFireRate = 0;
    public float fireRate = 1;
    Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;
        }
        if(Gamemanager.CannonStage == cannonStage.wait)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (currentFireRate <= 0)
                {
                    Shoot();
                }


            }
            else if (Input.GetMouseButton(0))
            {
                if (currentFireRate <= 0)
                {
                    Shoot();
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (currentFireRate <= 0)
                {
                    Shoot();
                }
            }
        }
        

    }

    void Shoot()
    {
        Debug.Log("geldi");
        GameObject newCh = Instantiate(characterPrefabs, spawnPoint.position, Quaternion.identity);
        _gameManager.characterList.Add(newCh);
        newCh.transform.eulerAngles = new Vector3(0, -180, 0);
        
        currentFireRate = fireRate;
    }
}
