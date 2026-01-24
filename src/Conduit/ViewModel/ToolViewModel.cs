using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Conduit.ViewModel
{
    /// <summary>
    /// View model for a tool
    /// </summary>
    public partial class ToolViewModel : ObservableValidator
    {
        /// <summary>
        /// Id for the tool
        /// </summary>
        [Required]
        [MinLength(1)]
        [RegularExpression(@"^[a-z0-9.]+$", ErrorMessage = "Id must contain only alphanumeric characters or periods.")]
        [ObservableProperty]
        private string _id = String.Empty;

        /// <summary>
        /// Name of the tool
        /// </summary>
        [Required]
        [MinLength(1)]
        [ObservableProperty]
        private string _name = "Unknown";

        /// <summary>
        /// Description of tool
        /// </summary>
        [ObservableProperty]
        private string _description = "Unknown";

        /// <summary>
        /// Gets or sets the semver version string
        /// </summary>
        [ObservableProperty]
        private string _version = "0.0.0";

        /// <summary>
        /// Link to source code
        /// </summary>
        [ObservableProperty]
        private string _source = "about:blank";

        /// <summary>
        /// Link to documentation
        /// </summary>
        [ObservableProperty]
        private string _documentation = "about:blank";

        [ObservableProperty]
        private string _website = "about:blank";

        /// <summary>
        /// command to install
        /// </summary>
        [ObservableProperty]
        [Required]
        [MinLength(1)]
        private string _install = string.Empty;

        /// <summary>
        /// command to uninstall
        /// </summary>
        [ObservableProperty]
        [Required]
        [MinLength(1)]
        private string _uninstall = string.Empty;

        /// <summary>
        /// Keywords for the tool
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> _keywords = new ObservableCollection<string>();

        /// <summary>
        /// Command to execute tool
        /// </summary>
        [ObservableProperty]
        [Required]
        [MinLength(1)]
        private string _command = String.Empty;

        /// <summary>
        /// Args to the command
        /// </summary>
        [ObservableProperty]
        private string _args = string.Empty;

        /// <summary>
        /// Desitred initial width of terminal
        /// </summary>
        [ObservableProperty]
        private int _width = 80;

        /// <summary>
        /// Desired initial height of terminal
        /// </summary>
        [ObservableProperty]
        private int _height = 25;

        /// <summary>
        /// tool icon which 4 lines of 8 characters each
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> _icon = new ObservableCollection<string>();

        /// <summary>
        /// Validates this model instance using data annotations.
        /// </summary>
        public void Validate()
        {
            var context = new ValidationContext(this);
            Validator.ValidateObject(this, context, validateAllProperties: true);
        }
    }
}
