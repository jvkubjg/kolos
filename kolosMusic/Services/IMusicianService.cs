using System;
using System.Threading.Tasks;

namespace kolosMusic.Services
{
    public interface IMusicianService
    {
        Task<bool> DeleteMusician(int IdMusician);
    }
}
