using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace AdvancedRoutingApp.RouteConstraints
{
    public class CategoryConstraint : IRouteConstraint
    {
        private readonly HashSet<string> _allowed = new() { "electronics", "books", "fashion" };

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value is string category)
            {
                return _allowed.Contains(category.ToLower());
            }

            return false;
        }
    }
}
