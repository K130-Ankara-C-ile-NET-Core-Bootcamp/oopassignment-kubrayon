using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPAssignment.Interfaces;

namespace OOPAssignment.Class
{
    public class CarCommandExecutorBase
    {
        protected readonly ICarCommand CarCommand;
        public CarCommandExecutorBase(ICarCommand carCommand)
        {
            CarCommand = carCommand;
        }
    }
}
