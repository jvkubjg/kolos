using System;
using System.Linq;
using System.Threading.Tasks;
using kolosMusic.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolosMusic.Services
{
    public class MusicianService

    {
        private readonly S20813Context _context;

        public MusicianService(S20813Context context)
        {
            _context = context;
        }


      //  public Task<bool> DeleteMusician(int IdMusician) // If not valid
       // {
            //var musican = await _context.Musicians.SingleOrDefaultAsync(e => e.IdMusician == IdMusician);
      //      return false;
      //  }

    }
}
