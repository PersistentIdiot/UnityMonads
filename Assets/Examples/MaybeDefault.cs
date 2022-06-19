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

        public TDefault Get() {
            return Default;
        }
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
    }
    /*
    public class Client {
        Client() {
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
    */
    /*
    public class StringToGameObjectOrException : MaybeTest<T,U><GameObject> {
        public StringToGameObjectOrException(GameObject someValue) : base(someValue) { }
    }

    
    public interface IMaybeDefault<out TDefault, U> {
        // ReSharper disable once UnusedMemberInSuper.Global // Ignore Rider is saying 'Only implementations of these are used' as that's intended
        TDefault Default { get; }

        // ReSharper disable once UnusedMemberInSuper.Global
        MaybeTest<TDefault,U><GameObject> MaybeGetNewGameObject(string requestedObjectName);
    }

    public class GameObjectMaybeDefaultRepo : IMaybeDefault<GameObject> {
        public TDefault Default { get; set; }

        public MaybeTest<T,U><GameObject> MaybeGetNewGameObject(string requestedObjectName) {
            if (requestedObjectName == "Null") {
                throw new Exception("Null object requested.");
            }
            else {
                return new StringToGameObjectOrException(Default);
            }
        }
    }

    public class Client {
        Client() {
            GameObjectMaybeDefaultRepo repo = new GameObjectMaybeDefaultRepo();
            MaybeTest<T,U><GameObject> GameObjectOrError = repo.MaybeGetNewGameObject("Not null").Bind(EnsureGameObjectNotNull);
            GameObjectOrError.Value.name = "GameObject.Name";
        }

        private MaybeTest<T,U><GameObject> EnsureGameObjectNotNull(GameObject arg) {
            if (arg == null) {
                throw new Exception("Game Object was null. This exception exists because of a contract the Monad imposed");
            }
            else {
                return new StringToGameObjectOrException(new GameObject());
            }
        }
    }
    */
}