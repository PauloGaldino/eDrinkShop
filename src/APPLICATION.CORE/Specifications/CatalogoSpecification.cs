using System;
using System.Linq.Expressions;
using APPLICATION.CORE.Entities;

namespace APPLICATION.CORE.Specifications
{
    public class CatalogoSpecification : BaseSpecification<CatalogoItem>
    {
        public CatalogoSpecification(int? marcaId, int? tipoId)
            :base(i => (!marcaId.HasValue || i.CatalogoMarcaId == marcaId) && (!tipoId.HasValue || i.CatalogoTipoId==tipoId))
        {
        }
    }
}
