using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monads.MaybeGameObjectMonad {
    public class Maybe<T> where T : class {
        public T Value { get => value; }
        private readonly T value;

        public Maybe(T someValue) {
            if (someValue == null)
                throw new ArgumentNullException(nameof(someValue));
            this.value = someValue;
        }

        private Maybe() { }

        public Maybe<U> Bind<U>(Func<T, Maybe<U>> func) where U : class { return value != null ? func(value) : Maybe<U>.None(); }

        public static Maybe<T> None() => new Maybe<T>();
    }

    public class MaybeReturnDefaultGameObject : Maybe<GameObject> {
        public MaybeReturnDefaultGameObject(GameObject someValue) : base(someValue) { }
    }

    public interface IMaybeAwareRepository {
        // Not sure why it's saying 'Only implementations of these are never used'
        GameObject DefaultGameObject { get; }

        Maybe<GameObject> MaybeGetNewGameObject(string requestedObjectName);
    }

    public class MaybeGameObjectRepo : IMaybeAwareRepository {
        public GameObject DefaultGameObject { get; set; }

        public Maybe<GameObject> MaybeGetNewGameObject(string requestedObjectName) {
            if (requestedObjectName == "Null") {
                throw new Exception("Null object requested.");
            }
            else {
                return new MaybeReturnDefaultGameObject(DefaultGameObject);
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
                return new MaybeReturnDefaultGameObject(new GameObject());
            }
        }
    }
}
