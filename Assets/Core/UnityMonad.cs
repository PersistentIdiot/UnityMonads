using System;
using System.Diagnostics;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;


namespace PI.Monads.Unity {
    /// <summary>
    /// <para>Unity Monad implementation</para>
    /// <para>Maps T to U</para>
    /// </summary>
    /// <typeparam name="T">Type to map from.</typeparam>
    /// <typeparam name="U">Type to map to.</typeparam>
    /// <remarks>ToDo: T and U seem backward... figure out if they are and swap if necessary. It makes more</remarks>
    public abstract class Monad<T, U> {
        public Monad(T instance) { }

        public abstract Monad<T, U> Bind(T param,Func<T, Monad<T, U>> f);

        public abstract Monad<T, U> Map(T param, Func<T, Monad<T, U>> func);
    }
}