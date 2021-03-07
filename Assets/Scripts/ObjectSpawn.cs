using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject m_OriginalGameObject;
    
    PoolObject m_PoolObjects;
    // Start is called before the first frame update
    void Start()
    {
        m_PoolObjects= new PoolObject(m_OriginalGameObject,5);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray  ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                // Vector3 pos= new Vector3(hit.transform.position.x,mousePos.y,hit.transform.position.z);
                GameObject newOject=m_PoolObjects.GetObjectFromPool();
                newOject.transform.position=new Vector3(hit.point.x,2,hit.point.z);
                StartCoroutine(DelayForDisable(newOject));
            }
           
        }
    }
    IEnumerator DelayForDisable(GameObject obj){
        yield return new WaitForSeconds(4f);
        m_PoolObjects.ThrowToPool(obj);
    }
}
