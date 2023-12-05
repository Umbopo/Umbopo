using AutoMapper;
using Bode.Data.Interfaces;
using Bode.DTOs;
using Bode.Library.Interfaces;
using Bode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bode.Library.Services
{
    class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _repo;
        private readonly IMapper _mapper;
        public ProvinceService(IProvinceRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<bool> Create(ProvinceDto dto)
        {
            Province model = new();
            //model.Id = dto.Id;
            _mapper.Map(dto, model);
            //model.Name = dto.Name;
            _repo.Add(model);

            try
            {
                if (_repo.SaveAll().Result)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            
        }
    }
}
