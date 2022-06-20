using System;
using System.Collections;
using System.Collections.Generic;
using Com.PI.UnityMonads.Examples;
using PI.Monads.Unity;
using UnityEngine;


public class MaybeMonadTest : MonoBehaviour {
    [SerializeField] private GameObject TestObject;
    
    private void Awake() {
        Maybe<GameObject, string> GameObjectOrError = GameObjectMaybeDefaultRepo.Instance.MaybeGetNewGameObject("Default").Bind(TestObject, EnsureGameObjectNotNull) as Maybe<GameObject, string>;
        TestObject = GameObjectOrError.Value;
        Debug.LogFormat($"{GameObjectOrError.Value.name}");
    }

    // ToDo: This being on client makes monads seem pointless. Move this out 
    private Monad<GameObject, string> EnsureGameObjectNotNull(GameObject arg) {
        if (arg == default) {
            return GameObjectMaybeDefaultRepo.Instance.MaybeGetNewGameObject("Default");
        }
        else {
            return GameObjectMaybeDefaultRepo.Instance.MaybeGetNewGameObject(arg.name);
        }
    }
}