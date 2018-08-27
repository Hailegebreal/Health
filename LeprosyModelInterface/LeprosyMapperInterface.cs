using System;
using System.Linq.Expressions;

namespace AspNetCoreProject.LeprosyModelInterface
{
    public interface LeprosyMapperInterface
    {
        void MapFromLep(Expression<Func<object, object>> sourceMember);

        void MapFromLep2(Expression<Func<object, object>> sourceMember2);
    }
}
