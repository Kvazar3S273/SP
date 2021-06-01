using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf.Client.Validation
{
    public class ErrorsAddCar
    {
        public List<string> Fuel { get; set; }
        public List<string> Mark { get; set; }
        public List<string> Year { get; set; }
        public List<string> Model { get; set; }
        public List<string> Capacity { get; set; }
        public List<string> Image { get; set; }

        public List<string> ErrorRes()
        {
            List<string> result = new List<string>();
            if (Fuel != null)
                result.AddRange(Fuel);
            if (Mark != null)
                result.AddRange(Mark);
            if (Year != null)
                result.AddRange(Year);
            if (Model != null)
                result.AddRange(Model);
            if (Capacity != null)
                result.AddRange(Capacity); 
            if (Image != null)
                result.AddRange(Image);
            return result;
        }
    }

    public class AddCarValidation //: BaseValidation
    {
        public ErrorsAddCar Errors { get; set; }
    }
    //public abstract class BaseValidation
    //{
    //    public int Status { get; set; }
    //}
}
