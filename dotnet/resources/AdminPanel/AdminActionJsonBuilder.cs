using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GTANetworkAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AdminPanel
{
    internal static class AdminActionJsonBuilder
    {
        public static string GetAdminAction(MethodInfo[] methods, Predicate<MethodInfo> hasAccess)
        {
            var adminsActions = methods
                .Where(method => method.GetCustomAttribute<RemoteEventAttribute>() != null)
                .Where(method => hasAccess(method))
                .Select(method => new
                {
                    Name = GetActionTitle(method.GetRemoteEventString()),
                    Command = GetActionCommand(method.GetRemoteEventString()),
                    Description = GetActionDescription(method.GetRemoteEventString()),
                    Params = GetParams(method)
                }
            );
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented
            };
            return JsonConvert.SerializeObject(adminsActions, settings);
        }

        private static string GetRemoteEventString(this MethodInfo method) =>
            method.GetCustomAttribute<RemoteEventAttribute>()!.RemoteEventString;

        private static string GetActionTitle(string eventName) => throw new NotImplementedException();

        private static string GetActionCommand(string eventName) => eventName.Split(':')[^1];

        private static string GetActionDescription(string eventName) => throw new NotImplementedException();

        private static IEnumerable<(string Type, string Name, string Description)> GetParams(MethodInfo method) =>
            method.GetParameters().Select(parameter => (
                    GetParamName(parameter), 
                    GetParamType(parameter), 
                    GetParamDescription(parameter)
                    )
                );

        private static string GetParamName(ParameterInfo parameter) => throw new NotImplementedException();

        private static string GetParamType(ParameterInfo parameter) => throw new NotImplementedException();

        private static string GetParamDescription(ParameterInfo parameter) => throw new NotImplementedException();
    }
}