﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class AnimationLayer : BaseDemo
{
    private UnityArmatureComponent _mechaArmatureComp = null;
    // Use this for initialization
    protected override void OnStart()
    {
        // Load Mecha Data
        UnityFactory.factory.LoadDragonBonesData("mecha_1004d/mecha_1004d_ske");
        UnityFactory.factory.LoadTextureAtlasData("mecha_1004d/mecha_1004d_tex");

        // Build Mecha Armature
        this._mechaArmatureComp = UnityFactory.factory.BuildArmatureComponent("mecha_1004d");

        this._mechaArmatureComp.transform.localPosition = new Vector3(0.0f, -2.0f, 0.0f);

        //
        this._mechaArmatureComp.AddDBEventListener(EventObject.LOOP_COMPLETE, OnAnimationEventHandler);

        this._mechaArmatureComp.animation.FadeIn("walk", 0.2f, 0, 0);
    }

    void OnAnimationEventHandler(string type, EventObject eventObject)
    {
        var p = Random.Range(0.0f, 1.0f);
        if (p <= 0.3f)
        {
            var animationState = this._mechaArmatureComp.animation.FadeIn("attack_01", 0.2f, 0, 1);
            animationState.resetToPose = true;

            //
            animationState.AddBoneMask("chest");
            animationState.AddBoneMask("effect_l");
            animationState.AddBoneMask("effect_r");
        }
    }
}
