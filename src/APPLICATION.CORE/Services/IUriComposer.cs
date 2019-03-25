using APPLICATION.CORE.Interfaces;

namespace APPLICATION.CORE.Services
{
   public class UriComposer : IUriComposer
    {

        private readonly CatalogoSettings _catalogoSettings;

        public UriComposer(CatalogoSettings catalogoSettings) => _catalogoSettings = catalogoSettings;
        
        public string ComposeFotUri(string uriTemplate)
        {
            return uriTemplate.Replace("http://catalogbaseurltobereplaced", _catalogoSettings.CatalogoBaseUrl);
        }
    }
}
