using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject PalisadeWall1;

    [SerializeField]
    private GameObject PalisadeWall2;

    [SerializeField]
    private GameObject PalisadeWall3;

    [SerializeField]
    private GameObject PalisadeWall4;

    [SerializeField]
    private GameObject PalisadeWall5;

    [SerializeField]
    private GameObject PalisadeWall1;

    private float MaxMovement = 150.0f;

    private bool HasMovedFirst = false;
    private bool HasMovedSecond = false;
    private bool HasMovedThird = false;
    public int NumberOfKeys{  get; private set; }

    public void KeysCollected()
    {
        NumberOfKeys++;
    }

    private void Update()
    {
        if (NumberOfKeys == 6 && !HasMovedFirst)
        {
            MoveFirstWall();
            HasMovedFirst = true;
        }

        if (NumberOfKeys == 12 && !HasMovedSecond)
        {
            MoveSecondtWall();
            HasMovedSecond = true;
        }

        if (NumberOfKeys == 18 && !HasMovedThird)
        {
            MoveThirdWall();
            HasMovedThird = true;
        }
    }

    void MoveFirstWall()
    {
        PalisadeWallFirstBlock.transform.position += new Vector3(MaxMovement, 0, 0);
    }

    void MoveSecondtWall()
    {
        PalisadeWallSecondBlock.transform.position += new Vector3(MaxMovement, 0, 0);
    }

    void MoveThirdWall()
    {
        PalisadeWallThirdBlock.transform.position += new Vector3(MaxMovement, 0, 0);
    }
}
