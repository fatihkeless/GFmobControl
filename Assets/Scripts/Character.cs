using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public NavMeshAgent navCharacter;
    public Transform target;
    Gamemanager _gameManager;
    public GameObject particle;


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
            colorChange1(gameObject);
            particleOpen();

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            colorChange1(gameObject);
            colorChange1(other.gameObject);
            navCharacter.speed = 3f;
            target = other.gameObject.transform;
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
            other.gameObject.GetComponent<Enemy>().speed = 2f;
        }
    }

    public void particleOpen()
    {
       GameObject particleNew = Instantiate(particle, transform.position + new Vector3(0,1f,0), Quaternion.identity);
        Destroy(particleNew, 0.5f);
    }



    #region colorFunc

    private void colorChange1(GameObject obj)
    {

        Material mat = obj.transform.GetChild(1).GetComponent<Renderer>().material;

        Color startColor = mat.color;

        mat.DOColor(Color.white, 0.3f).OnComplete(() => mat.DOColor(startColor, 0.3f).OnComplete(() => Destroy(obj)));

    }
    private void colorChange2(GameObject obj, GameObject obj1)
    {

        Material mat = obj.transform.GetChild(1).GetComponent<Renderer>().material;
        Material mat1 = obj1.transform.GetChild(1).GetComponent<Renderer>().material;

        Color startColor = mat.color;
        Color startColor1 = mat1.color;

        mat.DOColor(Color.white, 0.3f).OnComplete(() => mat.DOColor(startColor, 0.3f).OnComplete(() => Destroy(obj)));
        mat1.DOColor(Color.white, 0.3f).OnComplete(() => mat1.DOColor(startColor1, 0.3f).OnComplete(() => Destroy(obj1)));

    }

    #endregion
}
