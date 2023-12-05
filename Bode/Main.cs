using Bode.DTOs;
using Bode.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bode
{
    public partial class Main : Form
    {
        private readonly IProvinceService _service;
        public Main(IProvinceService service)
        {
            _service = service;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add a province
            ProvinceDto dto = new();
            //dto.Id = 1;
            dto.Name = "Gauteng";
            _service.Create(dto);

        }
    }
}
