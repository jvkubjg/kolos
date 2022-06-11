using System;
using System.Linq;
using System.Threading.Tasks;
using kolosMusic.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolosMusic.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly S20813Context _context;

        public MusicianService(S20813Context context)
        {
            _context = context;
        }


        public async Task<bool> DeleteMusician(int IdMusician) // If not valid
        {
            //var musican = await _context.Musicians.SingleOrDefaultAsync(e => e.IdMusician == IdMusician);
            var musican = await _context.Musicians.Include(m => m.IdMusician).ThenInclude(mt => mt.).ThenInclude(t => t.IdMusicAlbum).Count()
        }

    }
}
