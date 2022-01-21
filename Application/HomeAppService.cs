using Exercises.Contract;
using Exercises.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercises.Application
{
    public class HomeAppService : IHomeService
    {
        /// <summary>
        /// ejercicio 1
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ResponseOne> PostAsync(RequestOne model)
        {
            try
            {
                List<int> list = new List<int>();
                for (int i = 0; i < model.dias; i++)
                {
                    if (i > 0)
                    {
                        model.lstCasas = list;
                        list = new List<int>();
                    }

                    for (int j = 0; j < model.lstCasas.Count; j++)
                    {
                        var next = j == model.lstCasas.Count - 1 ? 0 : model.lstCasas[j + 1];
                        var prev = j == 0 ? 0 : model.lstCasas[j - 1];
                        var result = prev == next ? 0 : 1;
                        list.Add(result);
                    }
                }

                return new ResponseOne() { dias = model.dias, entrada = model.lstCasas, salida = list };
            }
            catch (Exception ex)
            {

                throw new System.NotImplementedException();
            }

            
        }
        /// <summary>
        /// ejercicio 2
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<dynamic> PostAsync(RequestTwo data)
        {
            try
            {
                var tCamion = data.tamanioCamion - 30;
                var listpaquetes = data.lstPaquetes;
                listpaquetes.Sort();
                listpaquetes.Reverse();
                var count = 0;
                List<int> result = new List<int>();
                for (int i = 0; i < listpaquetes.Count; i++)
                {
                    if (tCamion.Equals(listpaquetes[i]) && count == 0)
                        listpaquetes.Remove(listpaquetes[i]);
                    if (tCamion.Equals(listpaquetes[i]) && count > 0)
                    {
                        var tamaño = tCamion -= listpaquetes[i] < 0 ? tCamion += listpaquetes[i] : tCamion -= listpaquetes[i];
                        result.Add(tamaño);
                        listpaquetes.Remove(listpaquetes[i]);
                        count++;
                    }
                    else
                    {
                        var tamaño = tCamion -= listpaquetes[i] < 0 ? tCamion += listpaquetes[i] : tCamion -= listpaquetes[i];
                        result.Add(tamaño);
                        data.lstPaquetes.Remove(listpaquetes[i]);
                        count++;
                    }
                }
                var concat = string.Join(',', result.Select(x => $"{x}"));
                var response = new Dictionary<string, object>()
            {
                {"tamaño del camion ", data.tamanioCamion },
                {"paquetes", data.lstPaquetes },
                {"resultado", $"[{concat}], La suma de los paquetes es {result.Sum()} , lo que permite dejar las 30 unidades de espacio requeridas. " }
            };

                return response;
            }
            catch (Exception)
            {

                throw new System.NotImplementedException();
            }
        }
    }
}
