using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevelBlock : MonoBehaviour
{
    [SerializeField] private RectTransform minorPos;
    [SerializeField] private RectTransform mainPos;
    [SerializeField] private List<GameObject> blockMenu;
    [SerializeField] private int blockIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveToNextLeveBlock()
    {
        var minorPos1 = minorPos.transform.position;
        blockMenu[blockIndex].transform.position = new Vector3(minorPos1.x, minorPos1.y, blockMenu[blockIndex].transform.position.z);
        blockIndex++;
        print($"gunIndex {blockIndex}");
        if (blockIndex >= blockMenu.Count)
        {
            blockIndex = 0;
        }
        var pos = mainPos.position;
        blockMenu[blockIndex].transform.position = new Vector3(pos.x, pos.y, blockMenu[blockIndex].transform.position.z);
    }


    public void BackToPrevLeveBlock()
    {
        var minorPos1 = minorPos.transform.position;
        blockMenu[blockIndex].transform.position = new Vector3(minorPos1.x, minorPos1.y, blockMenu[blockIndex].transform.position.z);
        blockIndex--;
        if (blockIndex < 0)
        {
            blockIndex = blockMenu.Count - 1;
        }
        var pos = mainPos.position;
        blockMenu[blockIndex].transform.position = new Vector3(pos.x, pos.y, blockMenu[blockIndex].transform.position.z);
    }
}
