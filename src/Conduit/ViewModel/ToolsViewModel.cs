using DynamicData;
using ObjectSearch;
using System.Collections.ObjectModel;
using YamlConverter;

namespace Conduit.ViewModel
{
    public class ToolsViewModel : ObservableCollection<ToolViewModel>
    {
        private readonly ObjectSearchEngine _toolSearch = new ObjectSearchEngine();

        public ToolsViewModel()
        {
            // add listener callback for items added to this collection
            this.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    _toolSearch.AddObjects(e.NewItems.Cast<ToolViewModel>());
                }
                if (e.OldItems != null)
                {
                    _toolSearch.RemoveObjects(e.OldItems.Cast<ToolViewModel>());
                }
            };

            this.AddRange(Directory.GetFiles(@"S:\github\Conduit\src\Conduit\Tools\", "*.yml")
               .Select(file =>
                {
                    try
                    {
                        var yaml = File.ReadAllText(file);
                        var tool = YamlConvert.DeserializeObject<ToolViewModel>(yaml);
                        tool.Validate();
                        return tool; 
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the error as needed
                        Console.WriteLine($"Error loading tool definition from {file}: {ex.Message}");
                    }
                    return null;
                })
                .Where(tool => tool != null));
        }

        public IEnumerable<ToolViewModel> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return this;
            }

            return _toolSearch.Search(query).Cast<ToolViewModel>();
        }

    }
}
