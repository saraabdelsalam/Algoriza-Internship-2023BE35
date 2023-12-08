using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Core_Layer.DTOs
{
   public class DoctorInfoDto
    {
        public Image Image;
        public string ImagePath;
        public string FullName;
        public string Email;
        public string PhoneNumber;
        public string Gender;
        public string Specialization;
        public int Price;
        public List<Days> Appointments;
    }
}
