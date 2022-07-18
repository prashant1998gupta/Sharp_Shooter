using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadingscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator loadingscene()
    {
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
