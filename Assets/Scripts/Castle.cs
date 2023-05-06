using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public int castleHealt;
    public Text healtText;

    public GameObject fireParticle;

    // Start is called before the first frame update
    void Start()
    {
        healtText.text = castleHealt.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        healtText.text = castleHealt.ToString();
        if(castleHealt <= 0)
        {
            Gamemanager.CannonStage = cannonStage.run;
            healtText.enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

        }
    }

    private void OnDestroy()
    {
        Gamemanager.CannonStage = cannonStage.run;


    }

}
