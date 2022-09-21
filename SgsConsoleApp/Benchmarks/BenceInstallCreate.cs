using BenchmarkDotNet.Attributes;
using Common.DI;
using HotFix.Protocol;
using LightInject;
using Microsoft.Extensions.DependencyInjection;
using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SgsConsoleApp.Benchmarks
{
    [MemoryDiagnoser]
    public class BenceInstallCreate
    {
        private static Type _type = typeof(PubGsCMoveCard);
        private static ConstructorInfo _constructor = _type.GetConstructor(Type.EmptyTypes);
        private static Delegate _delegate = Expression.Lambda(Expression.New(_type)).Compile();
        private static Func<object> _func = Expression.Lambda<Func<object>>(Expression.New(_type)).Compile();
        private static Func<PubGsCMoveCard>  _typedFunc = Expression.Lambda<Func<PubGsCMoveCard>>(Expression.New(_type)).Compile();
        private static LightInject.ServiceContainer container = new LightInject.ServiceContainer();

        private static MinimalContainer minContainer = new MinimalContainer();

        [GlobalSetup]
        public void Init()
        {
            container.Register<IProtocol, PubGsCMoveCard>("PubGsCMoveCard");
            minContainer.Register<IProtocol, PubGsCMoveCard > ();
        }

        [Benchmark]
        public PubGsCMoveCard ContainerMin()
        {
            var instance = minContainer.Create(typeof(IProtocol));
            return instance as PubGsCMoveCard;
        }

        [Benchmark]
        public PubGsCMoveCard Container()
        {
            var instance = container.GetInstance<IProtocol>("PubGsCMoveCard");
            return instance as PubGsCMoveCard;
        }

        [Benchmark]
        public PubGsCMoveCard New()
        {
            return new PubGsCMoveCard();
        }

        [Benchmark]
        public PubGsCMoveCard Activator()
        {
            return (PubGsCMoveCard)System.Activator.CreateInstance(typeof(PubGsCMoveCard));
        }


        [Benchmark]
        public PubGsCMoveCard Constructor()
        {
            return (PubGsCMoveCard)_constructor.Invoke(null);
        }

        [Benchmark]
        public PubGsCMoveCard Delegate()
        {
            return (PubGsCMoveCard)_delegate.DynamicInvoke();
        }

        [Benchmark]
        public PubGsCMoveCard Func()
        {
            return (PubGsCMoveCard)_func();
        }

        [Benchmark]
        public PubGsCMoveCard TypedFunc()
        {
            return _typedFunc();
        }
    }
}
