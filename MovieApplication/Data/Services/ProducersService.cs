using MovieApplication.Data.Base;
using MovieApplication.Models;

namespace MovieApplication.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDBContext context):base(context)
        {

        }
    }
}
