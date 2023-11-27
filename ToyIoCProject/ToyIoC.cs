using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyIoCProject
{
    public interface IToyIoC
    {
        IToyIoC AddSingleton<TInterface, TImplementation>();
    }

    public class ToyIoC_SimpleCase: IToyIoC
    {
        private readonly Dictionary<Type, Type> interfaceToImplementationMap = new();
        private readonly Dictionary<Type, object> instances = new();

        public IToyIoC AddSingleton<TImplementation>()
            => AddSingleton<TImplementation, TImplementation>();

        public IToyIoC AddSingleton<TInterface>(TInterface instance) where TInterface : class
        {
            instances.Add(typeof(TInterface), instance);
            return this;
        }

        public IToyIoC AddSingleton<TInterface, TImplementation>()
        {
            interfaceToImplementationMap.Add(typeof(TInterface), typeof(TImplementation));
            return this;
        }

        public TInterface Resolve<TInterface>()
        {
            return (TInterface)Resolve(typeof(TInterface));
        }

        private object Resolve(Type typeToResolve)
        {
            if (instances.TryGetValue(typeToResolve, out var instance))
            {
                return instance;
            }

            if (interfaceToImplementationMap.TryGetValue(typeToResolve, out var imp))
            {
                var ctor = imp.GetConstructors().FirstOrDefault();
                var ctorArgs = ctor.GetParameters().Select(p => Resolve(p.ParameterType)).ToArray();
                var resource = Activator.CreateInstance(imp, ctorArgs);
                if(resource != null)
                {
                    instances[typeToResolve] = resource;
                    return resource;
                }
                throw new ToyIoCException($"Failed to create instance for interface {typeToResolve.FullName}");
            }
            throw new ToyIoCException("No implementation found for " + typeToResolve.FullName);
        }

    }
}
