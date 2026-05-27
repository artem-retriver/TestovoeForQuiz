using Cysharp.Threading.Tasks;
using System.Threading;

public interface IService
{
    UniTask InitializeAsync(CancellationToken cancellationToken);
    UniTask ReleaseAsync(CancellationToken cancellationToken);
}