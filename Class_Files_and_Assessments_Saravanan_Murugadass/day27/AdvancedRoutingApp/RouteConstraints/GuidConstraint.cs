// File: RouteConstraints/GuidConstraint.cs
namespace AdvancedRoutingApp.RouteConstraints
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using System;

    public class GuidConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values[routeKey] == null) return false;
            return Guid.TryParse(values[routeKey]?.ToString(), out _);
        }
    }
}
