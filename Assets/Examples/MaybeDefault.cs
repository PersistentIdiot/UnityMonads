using System;
using UnityEngine;
using PI.Monads.Unity;
using Com.PI.UnityMonads.Examples;


namespace Com.PI.UnityMonads.Examples {
    public class StringToGameObjectOrException : Maybe<GameObject, string> {
        public StringToGameObjectOrException(GameObject someValue) : base(someValue) { }
    }

    /// <summary>
    /// <para>Creates a contract implementing types must abide by.</para>
    /// <para>The contract in this case being that the repo implementing this must return a game object when provided a string,
    /// and that game object must include a default value of type </para>
    /// <typeparamref name="IMaybeAwareRepository"/><typeparamref name="TDefault"/>.
    /// </summary>
    public interface IMaybeDefault<TDefault, U> {
        // ReSharper disable once UnusedMemberInSuper.Global // Ignore Rider is saying 'Only implementations of these are used' as that's intended
        public TDefault Default { get; }

        // ReSharper disable once UnusedMemberInSuper.Global
        Maybe<TDefault, U> MaybeGetNewGameObject(string requestedObjectName);

        public TDefault Get() { return Default; }
    }

    public class GameObjectMaybeDefaultRepo : IMaybeDefault<GameObject, string> {
        public GameObject Default { get; set; }

        public Maybe<GameObject, string> MaybeGetNewGameObject(string requestedObjectName) {
            if (requestedObjectName == "Default") {
                return new Maybe<GameObject, string>(Default);
                //return new Maybe<GameObject, string>(new GameObject(requestedObjectName));
            }
            else {
                GameObject newObject = new GameObject("New Object");
                return new Maybe<GameObject, string>(newObject);
                // Should I even throw here? I feel like I should just do nothing in this case.
                //throw new NotImplementedException();
            }
        }

        public void InitTestData() {
            // Initialize repo and populate with TestData
            Default = new GameObject("New Object");

        }
    }
}