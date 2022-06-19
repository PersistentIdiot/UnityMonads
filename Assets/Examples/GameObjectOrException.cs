using System;
using UnityEngine;
using Com.JonBrant.Monads;
using Com.PI.UnityMonads.Examples;


namespace Com.PI.UnityMonads.Examples {
    public class StringToGameObjectOrException : Maybe<GameObject, string> {
        public StringToGameObjectOrException(GameObject someValue) : base(someValue) { }
    }
    
    // From Recommended tags - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags
    /// <summary>
    /// <para>Creates a contract implementing types must abide by.</para>
    /// <para>The contract in this case being that the repo implementing this must return a game object when provided a string.
    /// That game object must include a default value of type </para>
    /// <typeparamref name="IMaybeAwareRepository"/><typeparamref name="TDefault"/>.
    /// <remarks> ToDo: Figure out why the 'out' parameter is needed here. Rider suggested it. Try removing it and breaking it later</remarks>
    /// </summary>
    public interface IMaybeDefault<TDefault, U> {
        // ReSharper disable once UnusedMemberInSuper.Global // Ignore Rider is saying 'Only implementations of these are used' as that's intended
        TDefault Default { get; }

        // ReSharper disable once UnusedMemberInSuper.Global
        Maybe<TDefault,U> MaybeGetNewGameObject(string requestedObjectName);
    }
    
    public class GameObjectMaybeDefaultRepo : IMaybeDefault<GameObject, string> {
        public GameObject Default { get; set; }

        public Maybe<GameObject,string> MaybeGetNewGameObject(string requestedObjectName) {
            if (requestedObjectName == "Default") {
                return new Maybe<GameObject, string>(Default);
            }
            else {
                // Should I even throw here? I feel like I should just do nothing in this case.
                throw new NotImplementedException();
            }
        }
    }
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