using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public GameObject mainShipOriginal;
    public GameObject mainGroupOriginal;

    public GameObject KamGroupOriginal;

    private Base_Group currentGroup;

    private GroupType [] levelGroupTypes = {GroupType.Kamikadze};
    private int groupCount = 0;

    Vector3 StartPosition = new Vector3(0, -4, 0);
    Vector3 StartPos = new Vector3 (0, 3, 0);
    void Start()
    {
        GameObject newmainShipOriginal = Instantiate(mainShipOriginal);
        newmainShipOriginal.transform.position = StartPosition;

        CreateNewGroup();
        groupCount++;
    }

    
    void Update()

    {
     if(currentGroup != null && currentGroup.isAlive != false)
        if(currentGroup.isAlive == false){
            if(groupCount == levelGroupTypes.Length){
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            } else {
             Destroy(currentGroup.gameObject);
             CreateNewGroup();
             groupCount++;
            }
        }
    }

    void CreateNewGroup()
    {
        GameObject newmainGroupOriginal = Instantiate(mainGroupOriginal);
        newmainGroupOriginal.transform.position = StartPos;
        currentGroup = newmainGroupOriginal.GetComponent<Simple_enemy_group>();
        print(newmainGroupOriginal);
        print(currentGroup);
    }
}
