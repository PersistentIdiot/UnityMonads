using System;
using System.Collections;
using System.Collections.Generic;
using Com.PI.UnityMonads.Examples;
using PI.Monads.Unity;
using UnityEngine;

public class MaybeMonadTest : MonoBehaviour {
    [SerializeField] private GameObject TestObject;
    private GameObjectMaybeDefaultRepo repo;
    private void Awake() {
        InitTestData();
        
        
        Maybe<GameObject, string> GameObjectOrError = repo.MaybeGetNewGameObject("Default");
        Debug.LogFormat($"{GameObjectOrError.Value.name}");
    }

    private Monad<GameObject, string> EnsureGameObjectNotNull(GameObject arg) {
        if (arg == default) {
            return new StringToGameObjectOrException(new GameObject("New Object."));
            //throw new Exception($"{nameof(Client)}.{nameof(EnsureGameObjectNotNull)}() - {nameof(arg)} was null. ");
        }
        else {
            return new Maybe<GameObject, string>(arg);
        }
    }

    private void InitTestData() {
        // Initialize repo and populate with TestData
        repo = new GameObjectMaybeDefaultRepo();
        repo.Default = TestObject == null ? new GameObject("New Object"): TestObject;
    }
}
