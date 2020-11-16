using System.Threading;
using System.Threading.Tasks;

namespace Core.Validations
{
    public interface IValidation<T>
    {
        Task Validate(T model, CancellationToken cancellationToken = default);
    }
}
