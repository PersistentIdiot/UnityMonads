using Com.PI.UnityMonads.Examples;
using PI.Monads.Unity;
using UnityEngine;


public class GameObjectMaybeDefaultRepo : Singleton<GameObjectMaybeDefaultRepo>, IMaybeDefault<GameObject, string> {
    [SerializeField] private GameObject _default;
    public GameObject Default { get => _default; set => _default = value; }

    public Maybe<GameObject, string> MaybeGetNewGameObject(string requestedObjectName) {
        if (requestedObjectName == "Default") {
            return new Maybe<GameObject, string>(Default);
        }
        else {
            GameObject newObject = new GameObject("New Object");
            return new Maybe<GameObject, string>(newObject);
        }
    }
}