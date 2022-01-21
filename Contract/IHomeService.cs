using Exercises.Model;
using System.Threading.Tasks;

namespace Exercises.Contract
{
    public interface IHomeService
    {
        Task<ResponseOne> PostAsync(RequestOne model);
        Task<dynamic> PostAsync(RequestTwo data);
    }
}
