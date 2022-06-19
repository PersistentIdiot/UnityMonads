using System;
using UnityEngine;


namespace PI.Monads.Unity {
    /// <summary>
    /// <para>Maybe Monad</para>
    /// <para>When given <typeparamref name="T"/>, returns <typeparamref name="T"/> or maybe <typeparamref name="U"/>.</para>
    /// </summary>
    /// <remarks>ToDo: make a Monad base class this inherits from. This is not the base Monad. Use Maybe again without Value</remarks>
    /// <typeparam name="T"></typeparam>
    public class Maybe<T, U>: Monad<T, U> {
        public T Value { get; }

        public Maybe(T instance) : base(instance) {
            Value = instance;
        }

        public override Monad<T, U> Bind(T param,Func<T, Monad<T, U>> f) {
            return Map(param, f);
        }

        public override Monad<T, U> Map(T param, Func<T, Monad<T, U>> f) {
            if (f != null) {
                return f.Invoke(param);
            }
            else {
                Debug.Assert(f != null, nameof(f) + " != null");
                return f.Invoke(param);
            }
        }

        
    }
}