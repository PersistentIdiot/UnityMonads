using System;
using UnityEngine;
using PI.Monads.Unity;
using Com.PI.UnityMonads.Examples;


namespace Com.PI.UnityMonads.Examples {
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
    }
}