using System;
using System.Linq.Expressions;
using APPLICATION.CORE.Entities;

namespace APPLICATION.CORE.Specifications
{
    public class CatalogoFilterPaginatedSpecification : BaseSpecification<CatalogoItem>
    {
        public CatalogoFilterPaginatedSpecification( int skip, int take, int? marcaId,int? tipoId)
            :base(i => (!marcaId.HasValue || i.CatalogoMarcaId == marcaId)&&(!tipoId.HasValue || i.CatalogoTipoId == tipoId))
        {
            ApplyPaging(skip, Take);
        }
    }
}
