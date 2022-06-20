using System;
using System.Collections;
using System.Collections.Generic;
using Com.PI.UnityMonads.Examples;
using PI.Monads.Unity;
using UnityEngine;


public class MaybeMonadTest : MonoBehaviour {
    [SerializeField] private GameObject TestObject;
    private void Awake() {

        // Bug: This should require EnsureGameObjectNotNull to be passed to Bind, but appears to work without it. Adding bind causes multiple new objects to be created.
        // Try moving test data into repo instead.
        // New Bug: New object is created in both cases.

        GameObjectMaybeDefaultRepo repo = new GameObjectMaybeDefaultRepo();
        repo.InitTestData();
        Maybe<GameObject, string> GameObjectOrError = repo.MaybeGetNewGameObject("Default").Bind(TestObject, EnsureGameObjectNotNull) as Maybe<GameObject, string>;
        Debug.LogFormat($"{GameObjectOrError.Value.name}");
    }

    private Monad<GameObject, string> EnsureGameObjectNotNull(GameObject arg) {
        if (arg == default) {
            return new StringToGameObjectOrException(new GameObject("New Object."));
            //throw new Exception($"{nameof(Client)}.{nameof(EnsureGameObjectNotNull)}() - {nameof(arg)} was default. ");
        }
        else {
            return new Maybe<GameObject, string>(arg);
        }
    }
}