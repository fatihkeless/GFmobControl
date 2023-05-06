using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public NavMeshAgent navCharacter;
    public Transform target;
    Gamemanager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        navCharacter = GetComponent<NavMeshAgent>();
        target = _gameManager.target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            navCharacter.SetDestination(target.position);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Castle"))
        {

            other.gameObject.GetComponent<Castle>().castleHealt--;
            _gameManager.characterList.Remove(gameObject);
            Destroy(gameObject);

        }
    }
}
