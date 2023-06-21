using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ColliderLists : MonoBehaviour
    {
    public int iObjIndex;
    public bool isFiller;
    public List<ColliderLists> Siblings;
    public List<GameObject> collided;
    public GameObject MainBody;
    void Start()
    {
        Physics2D.IgnoreCollision(MainBody.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
        for (int i = 0; i < Siblings.Count; i++)
        {
            Physics2D.IgnoreCollision(Siblings[i].GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
        }
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        collided.Add(coll.gameObject);
    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        collided.Remove(coll.gameObject);
    }
}
