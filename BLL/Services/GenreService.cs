using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DTOs;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService:IGenresService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public GenreService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenres()
        {
            var genres = await this.unitOfWork.GenreRepository.GetAllAsync();
            var genresDTO = mapper.Map<IEnumerable<GenreDTO>>(genres);
            return genresDTO;
        }
    }
}
