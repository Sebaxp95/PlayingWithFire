using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBox : MonoBehaviour {

    int level = 3;
    public Sprite DestructionSprite;

    public void CheckDestructionLevel()
    {
        level--;
        this.GetComponent<SpriteRenderer>().sprite = DestructionSprite;
        if (level == 0) Destroy(this);
    }
}
