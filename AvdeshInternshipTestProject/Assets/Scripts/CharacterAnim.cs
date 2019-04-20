using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour {

    private Animator anim;
    private movement movement1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        movement1 = GetComponent<movement>();
    }
    // Update is called once per frame
    void Update () {

        if (SelectionManager.moving && movement1.isSelected)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
	}
}
