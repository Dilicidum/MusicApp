﻿using BLL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenresService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenres();
    }
}
