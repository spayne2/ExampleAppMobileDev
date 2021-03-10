using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleAppMobileDev
{
	public interface IToDoRestService
	{
		Task<List<TodoItem>> RefreshDataAsync();

		Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

		Task DeleteTodoItemAsync(string id);
	}
}
