using Tieto.TSU.Framework.DataAccess.Generic.Interface;
using Tieto.TSU.Framework.Services.Generic;
using DomainModels = Tieto.TSU.Performance.Domain;
using Tieto.TSU.Performance.MSSQL;

namespace Tieto.TSU.Performance.DataService.Controllers
{
    public class LanguagesController : BaseController<DomainModels.Language>
    {
        private readonly IGenericRepository<DomainModels.Language> genericRepository;

        public LanguagesController(ILocalizationRepository<DomainModels.Language> repository)
            : base(repository)
        {
            this.genericRepository = repository;
        }
    }
}
