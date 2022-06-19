using System;
using Com.JonBrant.Monads;
using UnityEngine;


namespace Monads.MaybeGameObjectMonad {
    public class StringToGameObjectOrException : Maybe<GameObject> {
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
    public interface IMaybeDefault<out TDefault> {
        // ReSharper disable once UnusedMemberInSuper.Global - Ignore Rider is saying 'Only implementations of these are used' as that's intended
        TDefault Default { get; }

        // ReSharper disable once UnusedMemberInSuper.Global
        Maybe<GameObject> MaybeGetNewGameObject(string requestedObjectName);
    }

    public class MaybeGameObjectRepo : IMaybeDefault<GameObject> {
        public GameObject Default { get; set; }

        public Maybe<GameObject> MaybeGetNewGameObject(string requestedObjectName) {
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
            MaybeGameObjectRepo repo = new MaybeGameObjectRepo();
            Maybe<GameObject> GameObjectOrError = repo.MaybeGetNewGameObject("Not null").Bind(EnsureGameObjectNotNull);
            GameObjectOrError.Value.name = "GameObject.Name";
        }

        private Maybe<GameObject> EnsureGameObjectNotNull(GameObject arg) {
            if (arg == null) {
                throw new Exception("Game Object was null. This exception exists because of a contract the Monad imposed");
            }
            else {
                return new StringToGameObjectOrException(new GameObject());
            }
        }
    }
}