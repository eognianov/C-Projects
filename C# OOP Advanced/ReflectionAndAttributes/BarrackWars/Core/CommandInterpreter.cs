using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;

namespace _03BarracksFactory.Core
{
    class CommandInterpreter:ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commnadType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName);

            if (commnadType == null)
            {
                throw new ArgumentException("Invalid Commnad!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commnadType))
            {
                throw new ArgumentException($"{commandName} is Not A Command");
            }

            FieldInfo[] fieldsToInject = commnadType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType==typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] constructorArgs =new object[]{data}.Concat(injectArgs).ToArray();
            IExecutable instance = (IExecutable)Activator.CreateInstance(commnadType, constructorArgs);

            return instance;

            
        }
    }
}
