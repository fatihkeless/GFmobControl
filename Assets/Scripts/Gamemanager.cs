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
        print(CannonStage);


        switch (GameStage)
        {
            case (gameStage.stage1):
                target = targetList[0];
                
                if (CannonStage == cannonStage.run)
                {
                    cannon.transform.DOMove(new Vector3(-2.34349871f, 0, -37.9981575f), 2.5f).OnComplete(() => 
                    cannon.transform.DORotate(new Vector3(270, 329, 0), 0.5f).OnComplete(()=>
                    upState(gameStage.stage2)));
                }
                else if (CannonStage == cannonStage.wait)
                {
                    targetList[0].gameObject.GetComponent<Castle>().castleFireBool = true;
                    targetList[1].gameObject.GetComponent<Castle>().castleFireBool = false;
                    targetList[2].gameObject.GetComponent<Castle>().castleFireBool = false;
                }

                break;
            case (gameStage.stage2):
                target = targetList[1];
                
                if (CannonStage == cannonStage.run)
                {
                    cannon.transform.DOMove(new Vector3(31.0499992f, 0.0900000036f, -91.2300034f), 2.5f).OnComplete(() => upState(gameStage.stage3));
                }
                else if (CannonStage == cannonStage.wait)
                {
                    targetList[0].gameObject.GetComponent<Castle>().castleFireBool = false;
                    targetList[1].gameObject.GetComponent<Castle>().castleFireBool = true;
                    targetList[2].gameObject.GetComponent<Castle>().castleFireBool = false;
                }

                break;
            case (gameStage.stage3):
                target = targetList[2];
                
                if (CannonStage == cannonStage.run)
                {
                    CannonStage = cannonStage.win;
                }
                else if(CannonStage == cannonStage.wait)
                {
                    targetList[0].gameObject.GetComponent<Castle>().castleFireBool = false;
                    targetList[1].gameObject.GetComponent<Castle>().castleFireBool = false;
                    targetList[2].gameObject.GetComponent<Castle>().castleFireBool = true;
                }

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
