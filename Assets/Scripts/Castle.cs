using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public int castleHealt;
    public Text healtText;
    Gamemanager _gameManager;

    public GameObject fireParticle;
    

    bool enableBool;

    public GameObject enemyPrefabs;
    public Transform spawnPoint;
    public bool castleFireBool;

    public float currentFireRate = 0;
    public float fireRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        healtText.text = castleHealt.ToString();
        enableBool = false;
        castleFireBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        healtText.text = castleHealt.ToString();
        if(castleHealt <= 0)
        {
            if (!enableBool)
            {
                Gamemanager.CannonStage = cannonStage.run;
                healtText.enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                enableBool = true;
            }
        }
        if (!enableBool && castleFireBool)
        {
            if (currentFireRate > 0)
            {
                currentFireRate -= Time.deltaTime;
            }
            if (currentFireRate <= 0)
            {
                Shoot();
            }
        }

        

    }


    private void OnDestroy()
    {
        Gamemanager.CannonStage = cannonStage.run;


    }
    void Shoot()
    {
        Debug.Log("geldi");
        GameObject newCh = Instantiate(enemyPrefabs, spawnPoint.position, Quaternion.identity);
        _gameManager.characterList.Add(newCh);
        
        if (_gameManager.GameStage == gameStage.stage1)
        {
            newCh.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_gameManager.GameStage == gameStage.stage2)
        {
            newCh.transform.eulerAngles = new Vector3(0, -30, 0);
        }
        else
        {
            newCh.transform.eulerAngles = new Vector3(0, -30, 0);
        }
        currentFireRate = fireRate;
    }
}
