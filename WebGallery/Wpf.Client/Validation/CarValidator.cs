using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf.Client.Validation
{
    public abstract class BaseValidation
    {
        public int Status { get; set; }
    }
    public class ErrorsAddCar
    {
        public List<string> Fuel { get; set; }
        public List<string> Mark { get; set; }
        public List<string> Year { get; set; }
        public List<string> Model { get; set; }
    }

    public class AddCarValidation : BaseValidation
    {
        public ErrorsAddCar Errors { get; set; }
    }
}
