using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
  private Camera myCamera;
  private Purse myPurse;
  public GameObject tower;
  public GameObject jelly;

  public Transform towerParent;
  public Transform fishParent;
    // Start is called before the first frame update
    void Start()
    {
      myCamera = GetComponent<Camera>();
      myPurse = GameObject.FindGameObjectWithTag("Purse").GetComponent<Purse>();
    }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Vector3 mouseClick = Input.mousePosition;
      //Debug.Log(mouseClick);

      Ray ray = myCamera.ScreenPointToRay(mouseClick);

      RaycastHit hit;
      if (Physics.Raycast(ray, out hit))
      {
        if (hit.transform.tag == "Enemy")
        {
          hit.transform.GetComponent<Enemy>().TakeDamage(20);
        }

        if (hit.transform.tag == "TowerPosition")
        {
          //Debug.Log(hit.transform.name + " Hit!");
          if (myPurse.PlaceTower(500))
          {
            Instantiate(tower, hit.transform.position, Quaternion.identity, towerParent);
            Destroy(hit.transform.gameObject);
          }
          
        }

      }
       // print("I'm looking at " + hit.transform.name);
      //else
        //print("I'm looking at nothing!");
    }

    //Spawn jellyfish randomly
    int num = Random.Range(1, 3000);
    if (num > 0 && num < 6)
        {
            //Instantiate(jelly, transform.tag.position, )
        }
  }
    
    
}
