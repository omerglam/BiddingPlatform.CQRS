using System;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.EF
{
    public class CascadedIncludes<T1,T2,T3>
    {
        public CascadedIncludes(Expression<Func<T1, T2>> mainInclude, Expression<Func<T2, T3>> secondaryInclude)
        {
            MainInclude = mainInclude ?? throw new ArgumentNullException(nameof(MainInclude));
            SecondaryInclude = secondaryInclude ?? throw new ArgumentNullException(nameof(secondaryInclude));
        }

        public Expression<Func<T1, T2>> MainInclude { get; }

        public Expression<Func<T2, T3>> SecondaryInclude { get; }
    }
}