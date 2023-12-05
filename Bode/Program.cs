using AutoMapper;
using Bode.Data;
using Bode.Data.Interfaces;
using Bode.Data.Repositories;
using Bode.DTOs;
using Bode.Helpers;
using Bode.Library.Interfaces;
using Bode.Library.Services;
using Bode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bode
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.AddProfile<AutoMapperProfiles>()
                    //cfg.AddProfile<FooProfile>();
                );
            
            //var mapper 

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataContext dbContext = new();
            IMapper mapper = new Mapper(config);
            IProvinceRepository repo = new ProvinceRepository(dbContext);
            IProvinceService province = new ProvinceService(repo, mapper);


            Application.Run(new Main(province));
        }
    }
}
