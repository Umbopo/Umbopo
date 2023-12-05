using Bode.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bode.Library.Interfaces
{
    public interface IProvinceService
    {
        public Task<bool> Create(ProvinceDto dto);
    }
}
