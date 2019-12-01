using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class RegisterValidator : IRegisterValidator
    {
        public List<string> ValidateRegister(List<string> _registers)
        {
            var newRegistersListToBeReturned = new List<string>();

            foreach (string register in _registers)
            {
                string incompletedRegisterWithoutSpace = register.Trim();

                if(incompletedRegisterWithoutSpace.Length == 12)
                {
                    incompletedRegisterWithoutSpace += Validator.ValidateCnpj(incompletedRegisterWithoutSpace);
                }

                if (incompletedRegisterWithoutSpace.Length == 9)
                {
                    incompletedRegisterWithoutSpace += Validator.ValidateCpf(incompletedRegisterWithoutSpace);
                }

                newRegistersListToBeReturned.Add(incompletedRegisterWithoutSpace);
            }

            return newRegistersListToBeReturned;
        }
    }
}
