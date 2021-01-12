using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using Clockwork.Models;
using Clockwork.Models.Annotations;
internal static class Extensions {
    internal static IQueryable<T> Include<T>(this IQueryable<T> q, DbContext context) where T : class
    {
        
        IEnumerable<INavigation> navigationProperties = context.Model.FindEntityType(typeof(T)).GetNavigations();
        foreach (var np in navigationProperties)
        {
            var ann = np.GetAnnotations();
            if (ann.Any(a => a.Name == "Include"))
                q = q.Include(np.Name);
        }
        return q;
    }

}