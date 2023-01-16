using MovieApplication.Data.Base;
using MovieApplication.Models;

namespace MovieApplication.Data.Services
{
    public class CinemasSerivce:EntityBaseRepository<Cinema>,ICinemasService
    {
        public CinemasSerivce(AppDBContext context):base(context)
        {

        }
    }
}
