using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator _animator;
    public GameObject OpenPanel = null;
    
    void Start()
    {
        _animator = GetComponent<Animator>();  
        
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenPanel.SetActive(true);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenPanel.SetActive(false);
           
            
        }
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

     void Update()
    {
        if(IsOpenPanelActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel.SetActive(false);
                if (_animator.GetBool("open") == false)
                {
                    _animator.SetBool("open", true);
                } else if (_animator.GetBool("open") == true)
                {
                    _animator.SetBool("open", false);
                }



            }
        }
    }
}
