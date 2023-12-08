using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs
{
    public class PatientInfoDto
    {
        public Image? PatientImage;
        public string ImagePath;
        public string PatientName;
        public string PatientEmail;
        public string PatientPhone;
        public string PatientGender;
    }
}
