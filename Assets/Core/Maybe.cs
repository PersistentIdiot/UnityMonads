using System;
using UnityEngine;


namespace Com.JonBrant.Monads {
    /// <summary>
    /// <para>Maybe Monad</para>
    /// <para>When given <typeparamref name="T"/>, returns <typeparamref name="T"/> or maybe <typeparamref name="U"/>.</para>
    /// </summary>
    /// <remarks>ToDo: make a Monad base class this inherits from. This is not the base Monad. Use Maybe again without Value</remarks>
    /// <typeparam name="T"></typeparam>
    public class Maybe<T, U>: Monad<T, U> {
        public Maybe(T instance) : base(instance) { }

        public override Monad<T, U> Bind(T param,Func<T, Monad<T, U>> f) {
            return Map(param, f);
        }

        public override Monad<T, U> Map(T param, Func<T, Monad<T, U>> f) {
            if (f != default) {
                return f.Invoke(param);
            }
            else {
                Debug.Assert(f != null, nameof(f) + " != null");
                return f.Invoke(param);
            }
        }
    }
    /*
    public class Maybe<T> where T : class {
        public T Value { get; }

        public Maybe(T someValue) {
            Value = someValue ?? throw new ArgumentNullException(nameof(someValue));
        }

        private Maybe() { }

        public Maybe<U> Bind<U>(Func<T, Maybe<U>> func) where U : class { return Value != null ? func(Value) : Maybe<U>.None(); }

        public static Maybe<T> None() => new Maybe<T>();
    }
    */
}