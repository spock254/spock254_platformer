﻿using UnityEngine;
using System.Collections;

public class RunEndOfScene : MonoBehaviour {

    ChangeLvLBehavior changeLvLBeh;
   // IChangeLvLBehavior ilvlbeh;
	// Use this for initialization
	void Start () {
       // ilvlbeh = NextScene.GetNextScene;
        changeLvLBeh = ChangeLvLBehavior.GetChangeLvLBehavior;
        
	
	}
	
	// Update is called once per frame
	void Update () {
        //changeLvLBeh.RunLvLBehavior(ilvlbeh);
        changeLvLBeh.RunLvLBehavior(ChangeLvLBehavior.LvLBehavior.NEXT_LVL);
	}
}