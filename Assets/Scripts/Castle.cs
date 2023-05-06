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
   

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        healtText.text = castleHealt.ToString();
        enableBool = false;
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
    }


    private void OnDestroy()
    {
        Gamemanager.CannonStage = cannonStage.run;


    }

}
