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
                    cannon.transform.DOMove(targetList[0].position, 2f).OnComplete(() => upState(gameStage.stage2));
                }

                    break;
            case (gameStage.stage2):
                target = targetList[1];
                if (CannonStage == cannonStage.run)
                {
                    cannon.transform.DOMove(targetList[1].position, 2f).OnComplete(() => upState(gameStage.stage3));
                }

                break;
            case (gameStage.stage3):
                target = targetList[2];
                if (CannonStage == cannonStage.run)
                {
                    CannonStage = cannonStage.win;
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
    IEnumerator delayStage(gameStage gameStage)
    {
        cannon.transform.DOMove(targetList[0].position, 2f);
        yield return new WaitForSeconds(2f);
        upState(gameStage);
    }
    void upState(gameStage gameStage)
    {
        CannonStage = cannonStage.wait;
        GameStage = gameStage;
        Debug.Log(GameStage);
        Debug.Log(CannonStage);
    }
}
