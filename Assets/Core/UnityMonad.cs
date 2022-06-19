using System;
using System.Diagnostics;


namespace Com.JonBrant.Monads {
    /// <summary>
    /// <para>Unity Monad implementation</para>
    /// <para> </para>
    /// <para>The generics are at the edge of my understanding</para>
    /// <para>Maps T to U</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public abstract class Monad<T, U> {
        public Monad(T instance) { }

        public abstract Monad<T, U> Bind(T param,Func<T, Monad<T, U>> f);

        public abstract Monad<T, U> Map(T param, Func<T, Monad<T, U>> func);
    }
    
    
    public class MaybeTest<T, U>: Monad<T, U> {
        public MaybeTest(T instance) : base(instance) { }

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
    public class UnityMonad<T> where T : class {
        public UnityMonad(T someValue) { Value = someValue ?? throw new ArgumentNullException(nameof(someValue)); }

        private UnityMonad() { }

        public UnityMonad<U> Bind<U>(Func<T, Maybe<U>> func) where U : class { return Value != null ? func(Value) : UnityMonad<U>.None(); }

        public static UnityMonad<T> None() => new UnityMonad<T>();
    }
    */
}