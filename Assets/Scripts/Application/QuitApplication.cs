using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        exit();
    }

    public void exit()
    {
        
        Application.Quit(); 
    }
}
