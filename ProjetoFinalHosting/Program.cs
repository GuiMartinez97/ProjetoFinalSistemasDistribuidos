using ProjetoFinal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(RegisterValidator));
            Uri endereco = new Uri("http://localhost:8733/ProjetoFinal/Service/Validate");
            host.AddServiceEndpoint(typeof(IRegisterValidator), new BasicHttpBinding(), endereco);
            try
            {
                host.Open();
                ExibeInformacoesDoServico(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                host.Abort();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void ExibeInformacoesDoServico(ServiceHost sh)
        {
            Console.WriteLine($"{sh.Description.ServiceType} online!");
            foreach (ServiceEndpoint se in sh.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }
    }
}
