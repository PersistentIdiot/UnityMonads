using System;
using System.Collections;
using System.Collections.Generic;
using Com.PI.UnityMonads.Examples;
using PI.Monads.Unity;
using UnityEngine;

public class MaybeMonadTest : MonoBehaviour
{
    private void Awake() {
        GameObjectMaybeDefaultRepo repo = new GameObjectMaybeDefaultRepo();
        Maybe<GameObject, string> GameObjectOrError = repo.MaybeGetNewGameObject("Name").Bind(repo.Default, EnsureGameObjectNotNull) as Maybe<GameObject, string>;
        if (GameObjectOrError != null) {
            GameObjectOrError.Value.name = "lol nice";
        }
        else {
            Debug.LogFormat("Why was this null?");
        }
    }

    private Monad<GameObject, string> EnsureGameObjectNotNull(GameObject arg) {
        if (arg == default) {
            throw new Exception($"{nameof(Client)}.{nameof(EnsureGameObjectNotNull)}() - {nameof(arg)} was null. ");
        }
        else {
            return new Maybe<GameObject, string>(arg);
        }
    }
}
