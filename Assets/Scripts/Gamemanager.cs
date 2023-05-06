using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public enum gameStage { stage1, stage2, stage3}
public enum cannonStage { run, wait,win,lose}

public class Gamemanager : MonoBehaviour
{

    public gameStage GameStage = new gameStage();
    public static cannonStage CannonStage = new cannonStage();
    public Transform target;
    public List<Transform> targetList = new List<Transform>();
    public GameObject cannon;
    public List<GameObject> characterList = new List<GameObject>();




    // Start is called before the first frame update
    void Start()
    {
        CannonStage = cannonStage.wait;
        GameStage = gameStage.stage1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            CannonStage = cannonStage.run;
        }

        switch (GameStage)
        {
            case (gameStage.stage1):
                target = targetList[0];
                if (CannonStage == cannonStage.run)
                {

                }

                    break;
            case (gameStage.stage2):
                target = targetList[1];

                break;
            case (gameStage.stage3):
                target = targetList[2];
                cannon.transform.localPosition = targetList[1].position;
                break;
        }

        

        if(CannonStage == cannonStage.run)
        {
            if(characterList.Count > 0)
            {
                for (int i = characterList.Count - 1; i >= 0; i--)
                {
                    GameObject obj = characterList[i];

                    // Objeyi yok et
                    Destroy(obj);

                    // Objeyi listeden çýkar
                    characterList.RemoveAt(i);
                }
            }
            
        }
    }

    void upState(gameStage gameStage)
    {
        CannonStage = cannonStage.wait;
        GameStage = gameStage;
        Debug.Log(GameStage);
        Debug.Log(CannonStage);
    }
}
