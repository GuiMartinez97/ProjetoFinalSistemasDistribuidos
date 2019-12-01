using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    static class Program
    {
        public static string __dataPath__ = "C:\\Users\\guilherme.oliveira.WEVOLOCAL\\Desktop\\FEI\\S. Distribuídos\\ProjetoFinal\\Data\\BASEPROJETO.txt\\BASEPROJETO.txt";
        public static string __resultsPath__ = "C:\\Users\\guilherme.oliveira.WEVOLOCAL\\Desktop\\FEI\\S. Distribuídos\\ProjetoFinal\\Data\\Results";
        public static string __currentData__ = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
        public static TextWriter __tsw__;
        public static int __portion__ = 1000;


        static void Main(string[] args)
        {
            __tsw__ = new StreamWriter($"{__resultsPath__}\\Result{__currentData__}.txt", true);
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

            List<string> lines = File.ReadAllLines(__dataPath__).ToList();

            int threadsQtd = lines.Count / __portion__;

            var taskList = new List<Task>(threadsQtd);

            int lastIndex = 0;

            var totalRegisterComputed = 0; 

            for (int i = 0; i < threadsQtd; i++)
            {
                List<string> listToBeSend = lines.GetRange(lastIndex, __portion__);
                lastIndex += __portion__;

                string[] result = SendRequest(listToBeSend);

                
                for (int j = 0; j < result.Length; j++)
                {
                    totalRegisterComputed++;
                    __tsw__.WriteLine(result[j]);
                    Console.WriteLine($"Resultado {result[j]} - {totalRegisterComputed}");
                }
            }

            watch.Stop();
            Console.WriteLine($"Tempo total: {watch.Elapsed}");
            Console.ReadLine(); 
        }

        private static string[] SendRequest(List<string> _registersToBeSended)
        {
            var validatorClient = new ValidadeRegister.RegisterValidatorClient();
            return validatorClient.ValidateRegister(_registersToBeSended.ToArray());
        }
    }
}
