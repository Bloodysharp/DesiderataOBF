using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BitObfuscator.Core.Enums;
using BitObfuscator.Helpers;
using Mono.Cecil;

namespace BitObfuscator.Core
{
    public class ObfuscatorEngine
    {
        private readonly Dictionary<ObfuscationFeature, IObfuscationPhase> _phases = new();

        public ObfuscatorEngine()
        {
            LoadPhases();
        }

        private void LoadPhases()
        {
            foreach (var type in typeof(ObfuscatorEngine).Assembly.GetReferencedAssemblies())
            {
                var asm = Assembly.Load(type);
                foreach (var t in asm.GetTypes())
                {
                    if (typeof(IObfuscationPhase).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    {
                        var instance = (IObfuscationPhase)Activator.CreateInstance(t);
                        _phases[instance.Feature] = instance;
                    }
                }
            }
        }

        public void Execute(ObfuscationContext context)
        {
            Logger.Info($"Loading module: {context.InputPath}");
            context.Module = ModuleDefinition.ReadModule(context.InputPath, new ReaderParameters { ReadWrite = true });

            foreach (var feature in context.EnabledFeatures)
            {
                if (_phases.TryGetValue(feature, out var phase))
                {
                    Logger.Info($"Applying: {feature}");
                    phase.Execute(context);
                }
                else
                {
                    Logger.Warn($"Feature not found: {feature}");
                }
            }

            Logger.Info($"Writing module to: {context.OutputPath}");
            context.Module.Write(context.OutputPath);
        }
    }

    public interface IObfuscationPhase
    {
        ObfuscationFeature Feature { get; }
        void Execute(ObfuscationContext context);
    }
}