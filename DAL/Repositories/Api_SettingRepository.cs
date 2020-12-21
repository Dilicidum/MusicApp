using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace DAL.Repositories
{
    public class Api_SettingRepository:Repository<ApiSetting>,IApiSettingRepository
    {
        private ApplicationDbContext Context
        {
            get { return context as ApplicationDbContext; }
        }

        public DbSet<ApiSetting> dbSet { get; }

        public Api_SettingRepository(ApplicationDbContext context) : base(context) { dbSet = Context.Set<ApiSetting>(); }

        public async Task<ApiSetting> GetLastApplicationTokenByApiName(string ApiName)
        {
            var ApiSettings =  await dbSet.Where(c => c.ApiName == ApiName && c.Type == TokenType.Application).ToListAsync();
            var result = ApiSettings.Where(c => c.IsExpired == false).LastOrDefault();
            return result;
        }

        public async Task<ApiSetting> GetLastSpotifyApiTokenByType(TokenType type,string ApiName="Spotify")
        {
            var ApiSettings = await dbSet.Where(c => c.ApiName == ApiName && type == TokenType.Streaming).ToListAsync();
            var result = ApiSettings.Where(c => c.IsExpired == false).LastOrDefault();
            return result;
        }

        public async Task<ApiSetting> GetLastStreamingTokenByApiName(string ApiName = "Spotify")
        {
            var ApiSettings = await dbSet.Where(c => c.ApiName == ApiName && c.Type == TokenType.Streaming).ToListAsync();
            var result = ApiSettings.Where(c => c.IsExpired == false).LastOrDefault();
            return result;
        }
    }
}
