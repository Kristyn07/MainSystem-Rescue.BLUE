using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerStageDone : MonoBehaviour
{
    //[SerializeField] Stage06Complete stagecomplete;
    [SerializeField] string Tag;
    public bool StageIsDone;
    [SerializeField] GameObject OnEnterActivate;
    [SerializeField] Stage06Complete Stage06;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag)
        {
            StageIsDone = true;
            OnEnterActivate.SetActive(true);
            Stage06.Check_Update();

        }
    }


}
