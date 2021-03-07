using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    Queue<GameObject> q_Object = new Queue<GameObject>();
    GameObject m_obj;
    
    public PoolObject(GameObject obj,int count){
        m_obj=obj;
        for(int i=0 ;i<=count;i++){
            GameObject newObj= Instantiate(obj,obj.transform.position,Quaternion.identity);
            newObj.SetActive(false);
            q_Object.Enqueue(newObj);
        }
        
    }
    public GameObject GetObjectFromPool(){
        if(q_Object.Count<=0){
            GameObject newObj= Instantiate(m_obj,m_obj.transform.position,Quaternion.identity);
            newObj.SetActive(false);
            q_Object.Enqueue(newObj);
        }
        GameObject obj=q_Object.Dequeue();
        obj.SetActive(true);
        return obj;
    }
    public void ThrowToPool(GameObject obj){
        obj.SetActive(false);
        q_Object.Enqueue(obj);
    }
    IEnumerator DelayForDisable(GameObject obj){
        yield return new WaitForSeconds(4f);
        obj.SetActive(false);
        q_Object.Enqueue(obj);
    }
}
