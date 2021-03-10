using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleAppMobileDev
{

	public interface IRepositoryRestService
	{
		Task<List<Repository>> GetRepositoriesAsync(string uri);
	}
}
